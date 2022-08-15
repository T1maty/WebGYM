using Microsoft.EntityFrameworkCore;
using ProductWebGYM.Models;

namespace ProductWebGYM.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)

        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Abonement> Abonements { get; set; }
    }
}
