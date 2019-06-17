using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Model.Context
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
