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

// PIIB22II02-153 MC-PL-1.6 Organize card of the coordinator role in a research group Task: PIIB22II02-250 Add coordinator mappings
namespace Infrastructure.People.EntityMappings
{
    internal class CoordinatorMap : IEntityTypeConfiguration<Coordinator>
    {
        public void Configure(EntityTypeBuilder<Coordinator> builder)
        {
            builder.ToTable("Coordinator");

            builder.Property(x => x.GroupId);
        }
    }
}
