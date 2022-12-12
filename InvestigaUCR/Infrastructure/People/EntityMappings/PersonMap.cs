using System;
using System.Linq;
using System.Text;
using LanguageExt;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.People.Relations;
using Domain.People.Entities;
using Domain.ResearchProjects.Entities;
using Domain.People.ValueObjects;

//ID US: PIIB22II02-59, task: PIIB22II02-293 Create entity map for people in infrastructure

namespace Infrastructure.People.EntityMappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasConversion(r => r.Value, s => RequiredString.TryCreate(s).Success());

            builder.Property(p => p.LastName1).HasConversion(r => r.Value, s => RequiredString.TryCreate(s).Success());

            builder.Property(p => p.LastName2).HasConversion(r => r.Value, s => RequiredString.TryCreate(s).Success());

            builder.Property(p => p.HighestDegree).HasConversion(r => r.Value, s => PersonHighestDegree.TryCreate(s).Success());

            builder.Property(p => p.University).HasConversion(r => r.Value, s => RequiredString.TryCreate(s).Success());

            // Mapping of Publications and People N:M
            builder.HasMany(pub => pub.Publications).WithMany(p => p.People).UsingEntity<Author>(
                j => j.ToTable("Author").HasOne(x => x.Publication).WithMany().HasForeignKey(x => x.DOI),
                j => j.ToTable("Author").HasOne(x => x.People).WithMany().HasForeignKey(x => new { x.Id }),
                j => j.ToTable("Author").HasKey(x => new { x.Id, x.DOI })
            );

            // Mapping of ResearchProjects and People N:M
            builder.HasMany(x => x.ResearchProjects)
                .WithMany(x => x.People)
                .UsingEntity<Collaborate>(
                j => j.ToTable("Collaborates").HasOne(x => x.ResearchProject).WithMany().HasForeignKey(x => x.ResearchProjectsId),
                j => j.ToTable("Collaborates").HasOne(x => x.Person).WithMany().HasForeignKey(x => new { x.PeopleId }),
                j => j.ToTable("Collaborates").HasKey(x => new { x.ResearchProjectsId, x.PeopleId })
            );
            
            builder.HasMany(t => t.MRResearchProjects).WithOne(p => p.MainResearcher!).HasForeignKey("PersonId");

            // Mapping of Theses and People N:M
            builder.HasMany(t => t.Theses).WithMany(p => p.People)
            .UsingEntity<Authors>(
                j => j.ToTable("Authors").HasOne(x => x.Theses).WithMany().HasForeignKey(x => x.IdThesis),
                j => j.ToTable("Authors").HasOne(x => x.People).WithMany().HasForeignKey(x => new { x.IdPerson }),
                j => j.ToTable("Authors").HasKey(x => new { x.IdThesis, x.IdPerson })
            );
        }
    }
}
