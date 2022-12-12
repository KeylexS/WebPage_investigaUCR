using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ResearchProjects.ValueObjects;
using Domain.Core.ValueObjects;
using Domain.Core.Helpers;
using Domain.ResearchProjects.Entities;
using Domain.People.Entities;
using Domain.Publications.Entities;
using Domain.ResearchAreas.Entities;

// Entity mapping for reasearch project
namespace Infrastructure.ResearchProjects.EntityMappings
{
    public class ResearchProjectsMap : IEntityTypeConfiguration<ResearchProject>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ResearchProject> builder)
        {
            builder.ToTable("ResearchProject");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(i => i.Id, n => ResearchProjectId.TryCreate(n).Success());
            builder.Property(p => p.Name);
            builder.Property(p => p.Start_date);
            builder.Property(p => p.End_date);
            builder.Property(p => p.Description);
            builder.Property(p => p.Image);


            builder.HasMany(x => x.Publications)
                   .WithMany(x => x._researchProjects)
                    .UsingEntity<Dictionary<string, object>>("ProjectsAssociatePublications",
                    x => x.HasOne<Publication>().WithMany().HasForeignKey("PublicationDOI"),
                    x => x.HasOne<ResearchProject>().WithMany().HasForeignKey("ResearchProjectId"));

            builder.HasMany(r => r.ResearchAreas)
               .WithMany(p => p.Projects)
                .UsingEntity<Dictionary<string, object>>("Associates_RArea",
                x => x.HasOne<ResearchArea>().WithMany().HasForeignKey("researchAreaId"),
                x => x.HasOne<ResearchProject>().WithMany().HasForeignKey("researchProjectId"));

            builder.HasMany(t => t.Theses).WithOne(p => p.ResearchProject).HasForeignKey("ResearchProjectId");

            builder.HasMany(x => x.People)
               .WithMany(x => x.ResearchProjects)
               .UsingEntity<Collaborate>(
               j => j.ToTable("Collaborates").HasOne(x => x.Person).WithMany().HasForeignKey(x => new { x.PeopleId }),
               j => j.ToTable("Collaborates").HasOne(x => x.ResearchProject).WithMany().HasForeignKey(x => x.ResearchProjectsId),
               j => j.ToTable("Collaborates").HasKey(x => new { x.ResearchProjectsId, x.PeopleId }));
        }
    }
}