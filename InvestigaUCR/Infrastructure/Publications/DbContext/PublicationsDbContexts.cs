
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Domain.Publications.Entities;
using Infrastructure.Publications.EntityMappings;
using Infrastructure.Core;
using Infrastructure.People.EntityMappings;
using Infrastructure.ResearchGroups.EntityMappings;
using LanguageExt;
using Infrastructure.ResearchProjects.EntityMappings;
using Infrastructure.Theses.EntityMappings;
using Infrastructure.News.EntityMappings;
using Domain.ResearchGroups.DTOs;
using Domain.People.Relations;
using Domain.ResearchGroups.Entities;

namespace Infrastructure.Publications.DbContexts
{
    public class PublicationsDbContext : ApplicationDbContext
    {
        //private readonly ILogger<ResearchProjectsDbContext> _logger;

        public PublicationsDbContext(DbContextOptions<PublicationsDbContext> options, ILogger<PublicationsDbContext> logger)
            : base(options, logger)
        {

        }

        public virtual DbSet<Publication> Publication { get; set; } = null!;

		//PIIB22II02-897 HT-PB-3.9 Show related groups
		public virtual DbSet<Group> Group { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PublicationsMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            //US: PIIB22II02 - 504 SD - RG - 3.6 Show a preview of the publications on theresearch group page TT: PIIB22II02 - 755 Change db Context of the entities
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new ResearchProjectsMap());
            modelBuilder.ApplyConfiguration(new ThesesMap());
            modelBuilder.ApplyConfiguration(new NewsMap());
        }


    }
}
