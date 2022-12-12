using Domain.News.Entities;
using Domain.ResearchGroups.Entities;
using Infrastructure.Core;
using Infrastructure.News.EntityMappings;
using Infrastructure.Publications.EntityMappings;
using Infrastructure.ResearchGroups.EntityMappings;
using Infrastructure.ResearchProjects.EntityMappings;
using Infrastructure.People.EntityMappings;
using Infrastructure.ResearchAreas.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Theses.EntityMappings;

namespace Infrastructure.News
{
    public class NewsDbContext : ApplicationDbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options, ILogger<NewsDbContext> logger) : base(options, logger)
        {
        }

        public virtual DbSet<GroupNews> News { get; set; } = null!;

       // public virtual DbSet<Group> Groups { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NewsMap());
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new ResearchProjectsMap());
            modelBuilder.ApplyConfiguration(new PublicationsMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new ResearchAreasMap());
            modelBuilder.ApplyConfiguration(new ThesesMap());
        }
    }
}

