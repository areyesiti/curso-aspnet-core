using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Data.Model
{
    public class Follower
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }
        public DateTime Date { get; set; }
        public User UserFollower { get; set; }
        public User UserFolling { get; set; }
    }
}
