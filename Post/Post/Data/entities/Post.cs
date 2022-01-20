using System;

namespace Post.Data.entities
{
    public class Post {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Desription { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}