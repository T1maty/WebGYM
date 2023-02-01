using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebGYM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebGYM.Persistance.EntityTypeConfigurations
{
    public class WebGYMConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(n => n.UserId);
            builder.HasIndex(n => n.UserId).IsUnique();
        }
        
    }
}
