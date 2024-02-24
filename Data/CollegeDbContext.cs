using ASP.NET_tut.Data.Config;
using ASP.NET_tut.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_tut.Data
{
    public class CollegeDbContext : DbContext 
    {

        public CollegeDbContext(DbContextOptions<CollegeDbContext>options): base(options)
        {
            
        }
        public DbSet<Students>Students {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfig());
        }
    }
}