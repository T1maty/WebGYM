using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGYM.Domain;
using WebGYM.Domain.Entities;
using WebGYM.Models;

namespace WebGYM.Application.Interfaces
{
    public interface IWebGymContext
    {
        DbSet<Domain.Entities.User> Users { get; set; }
        DbSet<Actual> Actuals { get; set; }
        DbSet<SportClub> SportClubs { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
