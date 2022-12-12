using System;
using System.Linq;
using System.Text;
using LanguageExt;
using System.Threading.Tasks;
using LanguageExt.ClassInstances;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Core;
using Domain.People.Relations;
using Domain.People.Entities;
using Domain.Publications.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.Entities;
using Infrastructure.People.EntityMappings;
using Infrastructure.Theses.EntityMappings;
using Infrastructure.Publications.EntityMappings;
using Infrastructure.ResearchAreas.EntityMappings;
using Infrastructure.ResearchGroups.EntityMappings;
using Infrastructure.ResearchProjects.EntityMappings;
using Infrastructure.News.EntityMappings;

//ID US: PIIB22II02-59, task: PIIB22II02-294 Create db context for people

namespace Infrastructure.People.Context.Implementation
{
    public class PeopleDbContext : ApplicationDbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options, ILogger<PeopleDbContext> logger)
            : base(options, logger)
        {
        }

        public virtual DbSet<Person> People { get; set; } = null!;

        public virtual DbSet<Coordinator> Coordinators { get; set; } = null!;

        public virtual DbSet<Researcher> Researchers { get; set; } = null!;

        public virtual DbSet<ResearchProject> ResearchProjects { get; set; } = null!;
        public virtual DbSet<Collaborate> Collaborates { get; set; } = null!;

        //PIIB22II02-525 MC-PL-2.8 Show research groups associated with a person | task: PIIB22II02-570	Create dbSet for groupsbyPersonID in PeopleDbContext. driver(AndreyMena), navigator(JoseFNuñez)
        public virtual DbSet<Group> Groups { get; set; } = null!;

        public virtual DbSet<Composedby> Composed_by { get; set; } = null!;

        //PIIB22II02-190 MC-PL-2.3 Show publications associated with a person | task: PIIB22II02-589 Implement the Repository and the DBContext for PersonID in Infrastructure layer
        public virtual DbSet<Author> Author { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // PIIB22II02-525 MC-PL-2.8 Show research groups associated with a person | task: PIIB22II02-577 Apply configuration to group in person for getPerson driver(JoséFNúñez), navigator(AndreyMena)
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            //PIIB22II02-190 MC-PL-2.3 Show publications associated with a person | task: PIIB22II02-589 Implement the Repository and the DBContext for PersonID in Infrastructure layer
            modelBuilder.ApplyConfiguration(new PublicationsMap());
            modelBuilder.ApplyConfiguration(new ResearchProjectsMap());
            modelBuilder.ApplyConfiguration(new ResearchAreasMap());
            modelBuilder.ApplyConfiguration(new ThesesMap());
            modelBuilder.ApplyConfiguration(new ComposedbyMap());
            modelBuilder.ApplyConfiguration(new CollaboratesMap());
            modelBuilder.ApplyConfiguration(new NewsMap());
            modelBuilder.ApplyConfiguration(new CoordinatorMap());
            modelBuilder.ApplyConfiguration(new ResearcherMap());
        }
    }
}
