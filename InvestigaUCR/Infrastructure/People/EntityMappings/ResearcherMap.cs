using Domain.Core.Helpers;
using Domain.People.Entities;
using Domain.ResearchGroups.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PIIB22II02-370 MC-PL-1.8 Organize card of the researcher role in a research group Task: PIIB22II02-1085 Add mappings of researcher
namespace Infrastructure.People.EntityMappings
{
    internal class ResearcherMap : IEntityTypeConfiguration<Researcher>
    {
        public void Configure(EntityTypeBuilder<Researcher> builder)
        {
            builder.ToTable("Researcher");

            builder.Property(x => x.GroupId);
        }
    }
}
