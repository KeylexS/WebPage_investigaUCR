using Domain.Users.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PIIB22II02-1225 MC-PL-5.13 User account details | PIIB22II02-1231 Add user account map

namespace Infrastructure.Users.EntityMappings
{
    public class UserAccountMap : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable("UserAccount");

            builder.Property(x => x.Id);

            builder.Property(x => x.Name);

            builder.Property(x => x.LastName1);

            builder.Property(x => x.LastName2);

            builder.Property(x => x.Descripcion);

            builder.Property(x => x.ProfilePicture);
        }
    }
}