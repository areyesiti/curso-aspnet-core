using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Data.Model
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Picture { get; set; }
        public DateTime date { get; set; }
        public User User {get; set;}
    }
}
