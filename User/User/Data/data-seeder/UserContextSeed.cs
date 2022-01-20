
using System;
using System.Collections.Generic;
using User.Data.datacontext;
using userEntity = User.Data.entities;

namespace User.Data.dataseeder
{
    public class UserContextSeed
    {
        private readonly UserDataContext _context;
        public UserContextSeed(UserDataContext context)
        {
            _context = context;
        }
        
        public void SeedUser() 
        {
            var _users = new List<userEntity.User>()
            {
                new userEntity.User { Id = 1001, Name = "User 1", CreatedOn = DateTime.UtcNow },
                 new userEntity.User { Id = 1002, Name = "User 2", CreatedOn = DateTime.UtcNow },
                  new userEntity.User { Id = 1003, Name = "User 3", CreatedOn = DateTime.UtcNow },
                   new userEntity.User { Id = 1004, Name = "User 4", CreatedOn = DateTime.UtcNow },
                    new userEntity.User { Id = 1005, Name = "User 5", CreatedOn = DateTime.UtcNow },
                     new userEntity.User { Id = 1006, Name = "User 6", CreatedOn = DateTime.UtcNow }
            };

            _users.ForEach(x => _context.Users.Add(x)); 
        }
    }
}