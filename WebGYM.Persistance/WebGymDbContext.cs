using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGYM.Domain;

namespace WebGYM.Persistance
{
    public class DbContextClass : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected readonly IConfiguration Configuration;
        public DbContextClass(DbContextOptions<DbContextClass> options) :
             base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}
