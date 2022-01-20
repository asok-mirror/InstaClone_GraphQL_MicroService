using HotChocolate;
using Post.Data.dtos;
using dataEntities = Post.Data.entities;
using Post.Data.repositories;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using HotChocolate.Data;

namespace Post.GraphQL
{
    public class Query
    {
        private readonly IMapper _mapper;
        public Query(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PostDTO GetPostById(int id, [Service] IGenericRepository<dataEntities.Post> postRepository) =>
            _mapper.Map<PostDTO>(postRepository.GetById(id));

        [UseFiltering]
        [UseSorting]
        public IEnumerable<PostDTO> GetPosts(int first, [Service] IGenericRepository<dataEntities.Post> postRepository) =>
            postRepository.GetAllAsQueryable().Take(first).Select(x => _mapper.Map<dataEntities.Post, PostDTO>(x));
    }
}
