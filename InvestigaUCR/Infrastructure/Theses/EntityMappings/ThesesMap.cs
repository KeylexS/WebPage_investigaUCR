using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Theses.Entities;


namespace Infrastructure.Theses.EntityMappings
{
    public class ThesesMap : IEntityTypeConfiguration<Thesis>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Thesis> builder)
        {
            builder.ToTable("Thesis");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title);
            builder.Property(t => t.Description);
            builder.Property(t => t._Type);
            builder.Property(t => t._Date);
        }
    }
}
