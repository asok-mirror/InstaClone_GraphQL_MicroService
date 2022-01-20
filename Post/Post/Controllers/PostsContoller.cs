
using Microsoft.AspNetCore.Mvc;
using Post.Data.dtos;
using Post.Services;
using System.Collections.Generic;

namespace Post.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IEnumerable<PostDTO> GetPost(int? pageNumber, int pageSize)
        {
            return _postService.GetAllPostsByPage(pageNumber, pageSize);
        }

        [HttpGet("{id}")]
        public PostDTO GetPost(int id)
        {
            return _postService.GetPostById(id);
        }
    }
}