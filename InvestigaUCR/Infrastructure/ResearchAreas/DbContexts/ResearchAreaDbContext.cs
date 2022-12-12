using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ResearchAreas.Entities;
using Infrastructure.ResearchAreas.EntityMappings;
using Infrastructure.Core;
using Infrastructure.People.EntityMappings;
using Infrastructure.ResearchProjects.EntityMappings;
using Infrastructure.ResearchGroups.EntityMappings;
using Infrastructure.Publications.EntityMappings;
using Infrastructure.Theses.EntityMappings;
using Infrastructure.News.EntityMappings;

namespace Infrastructure.ResearchAreas.DbContexts
{
    /// <summary>
    /// Class <c>ResearchAreasDbContext</c> Database context of Reserach Area entity
    /// </summary>
    public class ResearchAreasDbContext : ApplicationDbContext
    {
        /// <summary>
        /// ResearchAreasDbContext class parameterized constructor
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public ResearchAreasDbContext(DbContextOptions<ResearchAreasDbContext> options, ILogger<ResearchAreasDbContext> logger)
            : base(options, logger)
        {
        }

        public virtual DbSet<ResearchArea> ResearchArea { get; set; } = null!;

        /// <summary>
        /// Method <c>OnModelCreating</c> Add mappings necessaries by the Research Area entity
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ResearchAreasMap());
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new PublicationsMap());
            modelBuilder.ApplyConfiguration(new ResearchProjectsMap());
            modelBuilder.ApplyConfiguration(new ThesesMap());
            modelBuilder.ApplyConfiguration(new CollaboratesMap());
            modelBuilder.ApplyConfiguration(new NewsMap());
        }
    }
    
}
