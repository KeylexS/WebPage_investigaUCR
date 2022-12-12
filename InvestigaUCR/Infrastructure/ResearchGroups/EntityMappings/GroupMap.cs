using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.ResearchGroups.Entities;
using LanguageExt;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchAreas.Entities;
using LanguageExt.ClassInstances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection.Emit;


//User story:SD-RG-1.5 TT:PIIB22II02-281 Map the groups from DB
namespace Infrastructure.ResearchGroups.EntityMappings
{
    /// <summary>
    /// Class <c>GroupMap</c> Maps the Group entity and their relationships with other entities.
    /// </summary>
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        /// <summary>
        /// Method <c>Configure</c> Maps the group and their relationships with other entities in a builder.
        /// </summary>
        /// <param name="builder">An entity builder of Group entities</param>
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");
            //User story: |PIIB22II02-500 SD-RG-3.5 Show a preview of the research project on the research group page TT:  PIIB22II02 Make changes in the group map to add groups relations whit projects
            builder.Property(g => g.Id).HasConversion(r => r.Value, s => ResearchGroupId.TryCreate(s).Success());
            builder.HasKey(g => g.Id);
            builder.HasIndex(g => g.Id);
            builder.Property(g => g.Name).HasConversion(r => r.Value, s => ResearchGroupName.TryCreate(s).Success());
            builder.HasIndex(g => g.Name);
            builder.Property(g => g.ResearchCenterId);
            builder.HasMany(t => t.ResearchProjects).WithOne(p => p.Group!);
            builder.Property(g => g.Start_Date);
            builder.Property(g => g.Description).HasConversion(r => r.Value, s => ResearchGroupDescription.TryCreate(s).Success());
            //US: PIIB22II02-504 SD-RG-3.6 Show a preview of the publications on the research group page TT:PIIB22II02 - Add the mapping of publications in the groupmap
            builder.HasMany(t => t.Publications).WithOne(g => g.Group).HasForeignKey("ResearchGroupId");
            //US: PIIB22II02-350 SD-RG-1.6 Show the custom image for each groups in research groups list && TT: PIIB22II02-384 Map the group image from DB
            builder.Property(g => g.Image);
            //US: PIIB22II02-496 SD - RG - 1.10 Show group's research area && TT: PIIB22II02-638 Map the ResearchAreas on Group mapping
            builder.HasMany(g => g.ResearchArea)
                .WithMany(g => g.ResearchGroup)
                .UsingEntity(j => j.ToTable("GroupWorksOnArea"));
            builder.HasMany(g => g.Thesis).WithOne(n => n.ResearchGroup);
            builder.HasOne(g => g.Coordinator).WithMany(c => c.CoordinatorGroups).HasForeignKey("CoordinatorId");
            builder.HasMany(g => g.Person).WithMany(r => r.ResearchGroup).UsingEntity(j => j.ToTable("Composedby"));

            builder.HasMany(g => g.News).WithOne(n => n.Group!);
        }
    }
}
