
using Microsoft.AspNetCore.Mvc;
using User.Data.dtos;
using User.Services;
using System.Collections.Generic;

namespace User.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetUser(int? pageNumber, int pageSize)
        {
            return _userService.GetAllUsersByPage(pageNumber, pageSize);
        }

        [HttpGet("{id}")]
        public UserDTO GetUser(int id)
        {
            return _userService.GetUserById(id);
        }
    }
}