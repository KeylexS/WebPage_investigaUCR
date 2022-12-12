using Domain.News.Entities;
using Domain.People.Entities;
using Domain.People.Relations;
using Domain.Publications.Entities;
using Domain.ResearchAreas.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.Entities;
using Domain.Theses.Entities;
using Infrastructure.Core;
using Infrastructure.News.EntityMappings;
using Infrastructure.People.Context.Implementation;
using Infrastructure.People.EntityMappings;
using Infrastructure.Publications.EntityMappings;
using Infrastructure.ResearchAreas.EntityMappings;
using Infrastructure.ResearchGroups.EntityMappings;
using Infrastructure.ResearchProjects.EntityMappings;
using Infrastructure.Theses.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GeneralDbContext : ApplicationDbContext
    {
        /// <summary>
        /// GroupDbContext class parameterized constructor
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public GeneralDbContext(DbContextOptions<GeneralDbContext> options, ILogger<GeneralDbContext> logger) : base(options, logger)
        {
        }
        //User story SD-RG-1.3 & TT:  PIIB22II02-549 Make unit tests
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<ResearchArea> ResearchArea { get; set; } = null!;
        public virtual DbSet<GroupNews> News { get; set; } = null!;
        public virtual DbSet<Publication> Publications { get; set; } = null!;
        public virtual DbSet<ResearchProject> ResearchProject { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Thesis> Thesis { get; set; } = null!;

        public virtual DbSet<Coordinator> Coordinators { get; set; } = null!;

        public virtual DbSet<Researcher> Researchers { get; set; } = null!;

        public virtual DbSet<Collaborate> Collaborates { get; set; } = null!;

        public virtual DbSet<Composedby> Composed_by { get; set; } = null!;
        public virtual DbSet<Author> Author { get; set; } = null!;


        public int CantidadPorAnno(int anno) => ResearchProject.Take(1).Select(x => CantidadPorAnno(anno)).SingleOrDefault();
        public int ColaboradoresPorPublicacion(string id) => Author.Take(1).Select(x => ColaboradoresPorPublicacion(id)).SingleOrDefault();

        public int CantidadPorAnnoyArea(int area, int anno) => Author.Take(1).Select(x => CantidadPorAnnoyArea(area,anno)).SingleOrDefault();

        /// <summary>
        /// Method <c>OnModelCreating</c> Add mappings necessaries by the group entity
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDbFunction(typeof(GeneralDbContext).GetMethod(nameof(CantidadPorAnnoyArea))!);
            modelBuilder.HasDbFunction(typeof(GeneralDbContext).GetMethod(nameof(CantidadPorAnno))!);
            modelBuilder.HasDbFunction(typeof(GeneralDbContext).GetMethod(nameof(ColaboradoresPorPublicacion))!);
            modelBuilder.ApplyConfiguration(new GroupMap());
            //US: PIIB22II02-500 SD-RG-3.5 Show a preview of the research project on the research group page && TT: PIIB22II02 Add the mapping of groups and reseach projects to the groups dbContext and projects dbContext
            modelBuilder.ApplyConfiguration(new ResearchProjectsMap());
            modelBuilder.ApplyConfiguration(new ResearchAreasMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new PublicationsMap());
            modelBuilder.ApplyConfiguration(new ThesesMap());
            modelBuilder.ApplyConfiguration(new NewsMap());
            modelBuilder.ApplyConfiguration(new ComposedbyMap());
            modelBuilder.ApplyConfiguration(new CollaboratesMap());
            modelBuilder.ApplyConfiguration(new CoordinatorMap());
            modelBuilder.ApplyConfiguration(new ResearcherMap());
        }
    }
}
