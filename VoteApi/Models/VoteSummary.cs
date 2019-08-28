using System;
using System.Collections.Generic;

namespace VoteApi.Models
{
    public partial class VoteSummary
    {
        public int TotalVotes { get; set; }
        public int TotalHappyVote { get; set; }
        public int TotalUnhappyVote { get; set; }
        public int TotalAngryVote { get; set; }
    }
}
