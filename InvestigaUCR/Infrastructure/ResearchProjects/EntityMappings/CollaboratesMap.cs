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

// Entity mapping for reasearch project
namespace Infrastructure.ResearchProjects.EntityMappings
{
    public class CollaboratesMap : IEntityTypeConfiguration<Collaborate>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Collaborate> builder)
        {
            builder.ToTable("Collaborates");
            builder.HasKey(x => new { x.ResearchProjectsId, x.PeopleId });
            builder.HasOne(x => x.Person).WithMany(n => n.Collaborates).HasForeignKey(x => x.PeopleId);
            builder.HasOne(x => x.ResearchProject).WithMany(i => i.Collaborates).HasForeignKey(x => x.ResearchProjectsId);
            
            builder.Property(x => x.Orden);
        }
    }
}