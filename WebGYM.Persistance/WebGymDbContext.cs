using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGYM.Domain;
using WebGYM.Models;

namespace WebGYM.Persistance
{
    public class WebGymDbContext : DbContext
    {
        public DbSet<Domain.Entities.User> Users { get; set; }
        public DbSet<Actual> Actuals { get; set; }

        protected readonly IConfiguration Configuration;
        public WebGymDbContext(DbContextOptions<WebGymDbContext> options) :
             base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}
