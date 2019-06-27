using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Data.Model
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }        

        public User User { get; set; }
    }
}
