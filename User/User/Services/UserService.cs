using System;
using System.Collections.Generic;
using userEntities = User.Data.entities;
using System.Linq;
using User.Data.dtos;
using User.Data.repositories;
using AutoMapper;

namespace User.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsersByPage(int? pageNumber, int pageSize);

        UserDTO GetUserById(int id);
    }

    public class UserService : IUserService
    {
        private readonly IGenericRepository<userEntities.User> _userRepository;

        private readonly IMapper _mapper;

        public UserService(IGenericRepository<userEntities.User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> GetAllUsersByPage(int? pageNumber, int pageSize)
        {
            var users = _userRepository.GetAllByPage(pageNumber, pageSize);

            return users.Select(x => _mapper.Map<userEntities.User, UserDTO>(x));                     
        }

        public UserDTO GetUserById(int id)
        {
            var user = _userRepository.GetById<int>(id);

            return _mapper.Map<UserDTO>(user);          
        }
    }
}