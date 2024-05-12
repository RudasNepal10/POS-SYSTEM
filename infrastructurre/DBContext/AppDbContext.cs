using infrastructurre.DTO;
using infrastructurre.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructurre.DBContext
{

    public class AppDbContext : IdentityDbContext<User>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<AddProductATT> Product { get; set; }
        public DbSet<CategoryATT> Category { get; set; }
        public DbSet<CustomerATT> Customer { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("DBSchema");
            base.OnModelCreating(builder);
        }
      
    }
}
