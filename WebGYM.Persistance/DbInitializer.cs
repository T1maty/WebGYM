﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGYM.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(DbContextClass context)
        {
            context.Database.EnsureCreated();
        }
    }
}
