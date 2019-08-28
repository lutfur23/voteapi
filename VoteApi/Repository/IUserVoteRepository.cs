using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteApi.Models;

namespace VoteApi.Repository
{
    public interface IUserVoteRepository
    {
        UserVote GetUserVote(string VoterId);
        IEnumerable<UserVote> GetAllUserVote();
        UserVote AddUserVote(UserVote userVote);
        UserVote UpdateUserVote(UserVote userVote);
        UserVote DeleteUserVote(string VoterId);
    }
}
