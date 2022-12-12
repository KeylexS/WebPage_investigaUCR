using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.News.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.ValueObjects;
using LanguageExt;
using LanguageExt.ClassInstances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.News.EntityMappings
{
    public class NewsMap : IEntityTypeConfiguration<GroupNews>
    {
        public void Configure(EntityTypeBuilder<GroupNews> builder)
        {
            builder.ToTable("News");
            builder.HasKey(n => new { n.Id });
            builder.Property(n => n.Title);
            builder.Property(n => n.Description);
            builder.Property(n => n.Author);
            builder.Property(n => n.PublicationDate);
            //*builder.Property(n => n.GroupId);//*CQL
            builder.Property(n => n.Image);
            //builder.HasOne(n => n.Group)
            //    .WithOne(g => g.News)
            //    .HasForeignKey<Group>(g => g.GroupId);
        }
    }
}
 