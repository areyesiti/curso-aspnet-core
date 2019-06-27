using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Data.Model
{
    [Table("Users")]
    public class User
    {                
        public int Id { get; set; }

        [MaxLength(20)]
        [Column("UserName")]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserProfile Profile { get; set; }

        public IEnumerable<Follower> UserFollowers { get; set; }
        public IEnumerable<Follower> UserFollowings { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
