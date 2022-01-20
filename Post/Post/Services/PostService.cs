using System;
using System.Collections.Generic;
using postEntities = Post.Data.entities;
using System.Linq;
using Post.Data.dtos;
using Post.Data.repositories;

namespace Post.Services
{
    public interface IPostService
    {
        IList<PostDTO> GetAllPostsByPage(int? pageNumber, int pageSize);

        PostDTO GetPostById(int id);
    }

    public class PostService : IPostService
    {
        private readonly IGenericRepository<postEntities.Post> _postRepository;
        public PostService(IGenericRepository<postEntities.Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public IList<PostDTO> GetAllPostsByPage(int? pageNumber, int pageSize)
        {
            var posts = _postRepository.GetAllByPage(pageNumber, pageSize);

            return posts.Select(x => new PostDTO 
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CreatedOn = x.CreatedOn
                    }).ToList();               
        }

        public PostDTO GetPostById(int id)
        {
            var post = _postRepository.GetById<int>(id);

            return new PostDTO
            {
                Id = post.Id,
                Name = post.Name,
                CreatedOn = post.CreatedOn
            };
        }
    }
}