
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Domain.Theses.Entities;
using Infrastructure.Core;
using Infrastructure.Theses.EntityMappings;
using Infrastructure.ResearchGroups.EntityMappings;
using Infrastructure.People.EntityMappings;
using Infrastructure.ResearchProjects.EntityMappings;
using Infrastructure.News.EntityMappings;

namespace Infrastructure.Theses.DbContexts
{
    public class ThesesDbContext : ApplicationDbContext
    {
        public ThesesDbContext(DbContextOptions<ThesesDbContext> options, ILogger<ThesesDbContext> logger)
            : base(options, logger)
        {

        }

        public virtual DbSet<Thesis> Thesis { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ThesesMap());
            //US: PIIB22II02-527 HT-TS-1.2: Show thesis authors  TT: PIIB22II02-902 Fix thesis dbcontext
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new ResearchProjectsMap());
            modelBuilder.ApplyConfiguration(new NewsMap());
        }


    }
}
