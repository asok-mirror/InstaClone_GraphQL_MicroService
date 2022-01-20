using Microsoft.EntityFrameworkCore;
using postEntities = Post.Data.entities;

namespace Post.Data.datacontext
{
    public class PostDataContext : DbContext
    {
        public DbSet<postEntities.Post> Posts { get; set; }

        public PostDataContext(DbContextOptions options) : base(options)
        {
            
        }      
    }
}