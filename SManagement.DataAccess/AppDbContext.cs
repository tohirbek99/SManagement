using Microsoft.EntityFrameworkCore;
using SManagement.DataAccess.Models;
using SManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SManagement.DataAccess
{
  public  class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Staf> Stafs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
