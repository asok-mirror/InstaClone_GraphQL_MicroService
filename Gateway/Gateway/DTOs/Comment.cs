using System;

namespace Gateway.DTOs
{
    public class Comment
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public User User { get; set; }

    }
}
