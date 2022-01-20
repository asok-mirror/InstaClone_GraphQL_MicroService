using System;

namespace Post.Data.dtos
{
    public class PostDTO {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Desription { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}