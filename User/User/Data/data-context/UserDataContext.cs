using Microsoft.EntityFrameworkCore;
using userEntities = User.Data.entities;

namespace User.Data.datacontext
{
    public class UserDataContext : DbContext
    {
        public DbSet<userEntities.User> Users { get; set; }

        public UserDataContext(DbContextOptions options) : base(options)
        {
            
        }      
    }
}