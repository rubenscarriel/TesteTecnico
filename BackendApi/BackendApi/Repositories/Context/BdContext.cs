using BackendApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Repositories.Context
{
    public class BdContext : DbContext
    {
        public BdContext()
        {
            
        }

        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {  }

        public DbSet<User> Users { get; set; }
    }
}
