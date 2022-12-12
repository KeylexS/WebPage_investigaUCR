using Domain.ResearchAreas.Entities;
using Domain.ResearchProjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ResearchAreas.EntityMappings
{
    /// <summary>
    /// Class <c>ResearchAreasMap</c> Maps the Research Areas entity and their relationships with other entities.
    /// </summary>
    public class ResearchAreasMap : IEntityTypeConfiguration<ResearchArea>
    {
        /// <summary>
        /// Method <c>Configure</c> Maps the Research Area and their relationships with other entities in a builder.
        /// </summary>
        /// <param name="builder">An entity builder of Research Area entities</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ResearchArea> builder)
        {
            builder.ToTable("ResearchArea");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.Description);

            //builder.HasMany(p => p.Projects)
            //    .WithMany(a => a._researchAreas)
            //    .UsingEntity<Dictionary<string, object>>("Associates_RArea", x => x.HasOne<ResearchProject>().WithMany().HasForeignKey("researchProjectId"),
            //    x => x.HasOne<ResearchArea>().WithMany().HasForeignKey("researchAreaId"));

            //builder.HasMany(g => g.ResearchGroup)
            //   .WithMany(g => g.ResearchArea)
            //   .UsingEntity(j => j.ToTable("GroupWorksOnArea"));
        }
    }
}
