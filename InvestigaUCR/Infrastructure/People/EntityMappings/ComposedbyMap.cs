using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.People.Relations;

//PIIB22II02-59 MC-PL-1.3 People list in the research group. Add composed_byMap

namespace Infrastructure.People.EntityMappings
{
    public class ComposedbyMap : IEntityTypeConfiguration<Composedby>
    {
        public void Configure(EntityTypeBuilder<Composedby> builder)
        {
            builder.ToTable("Composed_by");

            builder.Property(c => c.researchGroupID);

            builder.Property(c => c.personalIdentification);

            //For testing in EF, the class needs a key. Also cant be multiple data duplicated in the pk.
            //For that, pk composite. (the ef map doesn't affect functionalities, is just to help EF read columns).
            builder.HasKey(c => new { c.researchGroupID, c.personalIdentification });
        }
    }
}
