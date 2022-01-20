
using Post.Data.datacontext;
using System;
using System.Collections.Generic;
using postEntity = Post.Data.entities;

namespace Post.Data.dataseeder
{
    public class PostContextSeed
    {
        private readonly PostDataContext _context;
        public PostContextSeed(PostDataContext context)
        {
            _context = context;
        }

        public void SeedPost()
        {
            var _posts = new List<postEntity.Post>()
            {
                new postEntity.Post { Id = 1, Name = "Post 1", ImageUrl="https://something.com/1.jpg", Desription="Description 1", CreatedOn = DateTime.UtcNow },
                 new postEntity.Post { Id = 2, Name = "Post 2", ImageUrl="https://something.com/2.jpg", Desription="Description 2", CreatedOn = DateTime.UtcNow },
                  new postEntity.Post { Id = 3, Name = "Post 3", ImageUrl="https://something.com/3.jpg", Desription="Description 3", CreatedOn = DateTime.UtcNow },
                   new postEntity.Post { Id = 4, Name = "Post 4", ImageUrl="https://something.com/4.jpg", Desription="Description 4", CreatedOn = DateTime.UtcNow },
                    new postEntity.Post { Id = 5, Name = "Post 5", ImageUrl="https://something.com/5.jpg", Desription="Description 5", CreatedOn = DateTime.UtcNow },
                     new postEntity.Post { Id = 6, Name = "Post 6", ImageUrl="https://something.com/6.jpg", Desription="Description 6", CreatedOn = DateTime.UtcNow }
            };

            _posts.ForEach(x => _context.Posts.Add(x));
        }
    }
}