using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteApi.Models;

namespace VoteApi.Repository
{
    public class UserVoteRepository : IUserVoteRepository
    {
        private readonly VotedbContext Context;
        public UserVoteRepository(VotedbContext context)
        {
            this.Context = context;
        }
        public UserVote AddUserVote(UserVote userVote)
        {
            Context.UserVote.Add(userVote);
            Context.SaveChanges();
            return userVote;
        }

        public UserVote DeleteUserVote(string VoterId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserVote> GetAllUserVote()
        {
            return Context.UserVote;
        }

        public UserVote GetUserVote(string VoterId)
        {
            throw new NotImplementedException();
        }

        public UserVote UpdateUserVote(UserVote userVote)
        {
            throw new NotImplementedException();
        }
    }
}
