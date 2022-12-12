using Domain.People.DTOs;
using Domain.ResearchGroups.Entities;
using Domain.ResearchAreas.Entities;
using Domain.Publications.Entities;
using Domain.News.Entities;
using Domain.Theses.Entities;
using Infrastructure.Core;
using Infrastructure.Publications.EntityMappings;
using Infrastructure.ResearchGroups.EntityMappings;
using Infrastructure.ResearchProjects.EntityMappings;
using Infrastructure.ResearchAreas.EntityMappings;
using Infrastructure.Theses.EntityMappings;
using Infrastructure.News.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.People.EntityMappings;
using Domain.ResearchProjects.Entities;

//User story:SD-RG-1.5 TT:PIIB22II02-289 Create Database context to Group entity
namespace Infrastructure.ResearchGroups
{
    /// <summary>
    /// Class <c>GroupDbContext</c> Database context of Group entity
    /// </summary>
    public class GroupDbContext : ApplicationDbContext
    {
        /// <summary>
        /// GroupDbContext class parameterized constructor
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public GroupDbContext(DbContextOptions<GroupDbContext> options, ILogger<GroupDbContext> logger) : base(options, logger)
        {
        }
        //User story SD-RG-1.3 & TT:  PIIB22II02-549 Make unit tests
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<ResearchArea> Areas { get; set; } = null!;
        
        public virtual DbSet<GroupNews> News { get; set; } = null!;
        public virtual DbSet<Publication> Publications { get; set; } = null!;

        public virtual DbSet<ResearchProject> ResearchProjects { get; set; } = null!;

        public virtual DbSet<Thesis> Theses { get; set; } = null!;

        /// <summary>
        /// Method <c>OnModelCreating</c> Add mappings necessaries by the group entity
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GroupMap());
            //US: PIIB22II02-500 SD-RG-3.5 Show a preview of the research project on the research group page && TT: PIIB22II02 Add the mapping of groups and reseach projects to the groups dbContext and projects dbContext
            modelBuilder.ApplyConfiguration(new ResearchProjectsMap());
            modelBuilder.ApplyConfiguration(new ResearchAreasMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new PublicationsMap());
            modelBuilder.ApplyConfiguration(new ThesesMap());
            modelBuilder.ApplyConfiguration(new NewsMap());
        }
    }
}
