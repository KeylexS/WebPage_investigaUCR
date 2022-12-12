using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Publications.Entities;


namespace Infrastructure.Publications.EntityMappings
{
    public class PublicationsMap : IEntityTypeConfiguration<Publication>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Publication> builder)
        {
            builder.ToTable("Publication");
            builder.HasKey(x => x.DOI);
            builder.Property(p => p.Name);
            builder.Property(p => p.Reference);
            builder.Property(p => p.Visibility);
            builder.Property(p => p.Type);
            builder.Property(p => p.Publisher_name);
            builder.Property(p => p.Abstract);
            builder.Property(p => p._Date);
            builder.HasMany(p => p.People).WithMany(r => r.Publications).UsingEntity(x => x.ToTable("Author"));
            //US: PIIB22II02-504 SD-RG-3.6 Show a preview of the publications on theresearch group page TT: PIIB22II02-755 Change db Context of the entities
            builder.HasOne(p => p.Group).WithMany(g => g.Publications).HasForeignKey("ResearchGroupId");
        }
    }
}
