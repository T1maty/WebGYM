﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGYM.Domain;
using WebGYM.Models;

namespace WebGYM.Application.Interfaces
{
    public interface IWebGymContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Activition> Activitions { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
