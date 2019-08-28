using System;
using System.Collections.Generic;

namespace VoteApi.Models
{
    public partial class UserVote
    {
        public int Id { get; set; }
        public string VoterId { get; set; }
        public bool? Happy { get; set; }
        public bool? Unhappy { get; set; }
        public bool? Angry { get; set; }
    }
}
