using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VoteApi.Models;
using VoteApi.Repository;

namespace VoteApi.Controllers
{
    [Route("api/[controller]")]
    public class VotesController : Controller
    {
        #region Fields and Properties
        IUserVoteRepository VoteRepo;
        #endregion

        #region Constructor
        public VotesController(IUserVoteRepository repo)
        {
            this.VoteRepo = repo;
        }
        #endregion

        #region public Endpoints and Methods
        // GET api/votes
        [HttpGet]
        public string Get()
        {
            var voteSummary = PrepareVoteSummary();
            return JsonConvert.SerializeObject(voteSummary, Formatting.Indented);
        }

        // POST api/votes
        [HttpPost]
        public string Post(UserVote uservote)
        {
            try
            {
                var userVoteDb = VoteRepo.GetUserVote(uservote.VoterId);

                // If uservote with current browser session does not exist create one
                if (userVoteDb == null)
                {
                    var savedvote = VoteRepo.AddUserVote(uservote);
                }
                // If uservote with current browser session exist then update the existing
                else
                {
                    userVoteDb.Happy = uservote.Happy;
                    userVoteDb.Unhappy = uservote.Happy;
                    userVoteDb.Angry = uservote.Happy;

                    var userVoteUpdated =  VoteRepo.UpdateUserVote(userVoteDb);
                }
                
            }
            catch (Exception ex)
            { }

            var voteSummary = PrepareVoteSummary();
            return JsonConvert.SerializeObject(voteSummary, Formatting.Indented);
        }
        #endregion

        #region Private method
        private VoteSummary PrepareVoteSummary()
        {
            VoteSummary voteSummary = new VoteSummary();
            try
            {
                var votes = VoteRepo.GetAllUserVote();

                foreach (var vote in votes)
                {
                    if (vote.Happy.Value)
                    {
                        voteSummary.TotalHappyVote += 1;
                    }
                    else if (vote.Unhappy.Value)
                    {
                        voteSummary.TotalUnhappyVote += 1;
                    }
                    else
                    {
                        voteSummary.TotalAngryVote += 1;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return voteSummary;
        }
        #endregion
    }
}
