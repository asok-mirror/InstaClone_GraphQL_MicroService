using System;
using System.Collections.Generic;

namespace Gateway.DTOs
{
    public class Post
    {       
        public int Id { get; set; }
       
        //public int UserId { get; set; }

        public string Img { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
