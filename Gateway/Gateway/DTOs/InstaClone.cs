using System.Collections.Generic;

namespace Gateway.DTOs
{
    public class InstaClone
    {
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
