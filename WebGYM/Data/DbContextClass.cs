using Microsoft.EntityFrameworkCore;
using WebGYM.Models;

namespace WebGYM.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(DbContextOptions<DbContextClass> options) :
             base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<User> Users { get; set; }
    }
}
