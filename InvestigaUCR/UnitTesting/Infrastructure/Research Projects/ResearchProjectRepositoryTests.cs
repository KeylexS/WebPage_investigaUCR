using Microsoft.EntityFrameworkCore;
using Moq;
using Domain.ResearchProjects.Entities;
using Domain.People.Entities;
using Domain.Publications.Entities;
using Domain.ResearchAreas.Entities;
using Domain.Theses.Entities;
using Infrastructure.ResearchProjects.Repositories;
using Xunit;
using FluentAssertions;
using Domain.ResearchProjects.Repositories;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging;
using Domain.ResearchProjects.ValueObjects;
using Domain.Core.Helpers;
using Domain.ResearchGroups.ValueObjects;
using System.Xml.Linq;
using Domain.ResearchGroups.Entities;
using Infrastructure;


// Unit tests for research project repository
namespace UnitTesting.Infraestructure.ResearchProjects
{
    public class ResearchProjectRepositoryTests
    {
        [Fact]
        public async void ResearchProjectRepositoryTestGetAllAsync()
        {
            // arrange
            var researchProjectsCountTest = 2;

            var options = new DbContextOptionsBuilder<GeneralDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabaseProject1")
                .Options;
            ILogger<GeneralDbContext> logger = null!;
            using (var context = new GeneralDbContext(options, logger))
            {
                System.DateTime date1 = new System.DateTime(2015, 3, 10, 2, 15, 10);
                System.DateTime date2 = new System.DateTime(2015, 7, 15, 6, 30, 20);
                context.ResearchProject.Add(new ResearchProject(ResearchProjectId.TryCreate("123-A1-123").Success(),  "Name1", date1, date2, "description1", null));
                context.ResearchProject.Add(new ResearchProject(ResearchProjectId.TryCreate("123-A2-123").Success(),  "Name2", date2, date1, "description2", null));
                context.SaveChanges();
            }
            using (var context = new GeneralDbContext(options, logger))
            {
                ResearchProjectRepository researchProjectRepository = new ResearchProjectRepository(context);

                // act
                var researchProjects = await researchProjectRepository.GetAllAsync();

                // assert
                researchProjects.Should().HaveCount(researchProjectsCountTest);

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async void ResearchProjectRepositoryTestGetByIdAsync()
        {
            // arrange
            var researchProjectsIdTest = "123-A1-123";
            DateTime date1 = new DateTime(2015, 3, 10, 2, 15, 10);
            DateTime date2 = new DateTime(2015, 7, 15, 6, 30, 20);
            ResearchProject researchProjectsTest = new ResearchProject(ResearchProjectId.TryCreate("123-A1-123").Success(), "Name1", date1, date2, "description1", null);

            var options = new DbContextOptionsBuilder<GeneralDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabaseProject2")
                .Options;
            ILogger<GeneralDbContext> logger = null!;
            using (var context = new GeneralDbContext(options, logger))
            {
                context.ResearchProject.Add(new ResearchProject(ResearchProjectId.TryCreate("123-A1-123").Success(), "Name1", date1, date2, "description1", null));
                context.ResearchProject.Add(new ResearchProject(ResearchProjectId.TryCreate("123-A2-123").Success(), "Name2", date2, date1, "description2", null));
                context.SaveChanges();
            }

            using (var context = new GeneralDbContext(options, logger))
            {
                ResearchProjectRepository researchProjectRepository = new ResearchProjectRepository(context);

                // act
                var researchProject = await researchProjectRepository.GetByIdAsync(researchProjectsIdTest);

                // assert
                researchProject.Should().BeEquivalentTo(researchProjectsTest);

                context.Database.EnsureDeleted();
            }
        }
    }
}
