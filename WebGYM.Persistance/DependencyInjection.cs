using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebGYM.Application.Interfaces;

namespace WebGYM.Persistance
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddPersistence( this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DefaultConnection"];
            services.AddDbContext<WebGymDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IWebGymDbContext>(provider => (IWebGymDbContext)provider.GetService<WebGymDbContext>());
            return services;

        }
    }
}
