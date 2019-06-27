using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Data.Dto
{
    public class PostInfoDto
    {
        public int Id { get; set; }        
        public string Picture { get; set; }
        public int Likes { get; set; }
        public int TotalComments { get; set; }        
    }
}
