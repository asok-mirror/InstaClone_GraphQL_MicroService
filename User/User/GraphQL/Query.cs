using HotChocolate;
using User.Data.dtos;
using dataEntities = User.Data.entities;
using User.Data.repositories;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using HotChocolate.Data;

namespace User.GraphQL
{
    public class Query
    {
        private readonly IMapper _mapper;
        public Query(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDTO GetUserById(int id, [Service] IGenericRepository<dataEntities.User> userRepository) =>
            _mapper.Map<UserDTO>(userRepository.GetById(id));

        [UseFiltering]
        [UseSorting]
        public IEnumerable<UserDTO> GetUsers([Service] IGenericRepository<dataEntities.User> userRepository) =>
            userRepository.GetAll().Select(x => _mapper.Map<dataEntities.User, UserDTO>(x));
    }
}
