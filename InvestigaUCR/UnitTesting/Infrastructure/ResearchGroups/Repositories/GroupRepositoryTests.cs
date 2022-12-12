using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.People.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchAreas.Entities;
using FluentAssertions;
using Infrastructure.People.Context.Implementation;
using Infrastructure.People.Repositories;
using Infrastructure.ResearchGroups;
using Infrastructure.ResearchGroups.Repositories;
using LanguageExt;
using LanguageExt.Pipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Core.ValueObjects.RequiredString;
using Domain.ResearchProjects.Entities;
using Domain.Publications.Entities;
using Domain.ResearchGroups.ValueObjects;
using Infrastructure;
using Domain.Theses.Entities;

//User story: SD-RG-1.5 & TT: PIIB22II02-287 Make unit tests
//US: PIIB22II02-350 SD-RG-1.6 Show the custom image for each groups in research groups list && TT: PIIB22II02-573 Update the Unit test
namespace UnitTesting.Infrastructure.ResearchGroups.Repositories
{
    public class GroupRepositoryTests
    {
        [Fact]
        public async void GroupRepositoryTestGetAllAsync()
        {
            // arrange
            var groupCountTest = 2;
            ILogger<GeneralDbContext> logger = null!;
            var options = new DbContextOptionsBuilder<GeneralDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            // Insert seed data into the database using one instance of the context
            byte[] aux = { 1, 1, 1 };
            using (var context = new GeneralDbContext(options, logger))
            {
                context.Groups.Add(new Group(ResearchGroupId.TryCreate("HCI").Success(), 1, ResearchGroupName.TryCreate("name1").Success(), ResearchGroupDescription.TryCreate("Generic description #1 to do testing").Success(), aux, null));
                context.Groups.Add(new Group(ResearchGroupId.TryCreate("HB").Success(), 1, ResearchGroupName.TryCreate("name2").Success(), ResearchGroupDescription.TryCreate("Generic description #2 to do testing").Success(), aux, null));
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new GeneralDbContext(options, logger))
            {
                GroupRepository groupRepository = new GroupRepository(context);

                // act
                var group = await groupRepository.GetAllAsync();

                // assert
                group.Should().HaveCount(groupCountTest);

                context.Database.EnsureDeleted();
            }
        }

        //User story SD-RG-1.3 & TT:  PIIB22II02-549 Make unit tests
        [Fact]
        public async void GroupRepositoryTestGetByIdAsync()
        {
            // arrange
            byte[] test = { 1, 1, 1 };
            var GroupIdTest = "HCI";
            List<ResearchArea> area = new List<ResearchArea>();
            List<ResearchProject> projects = new List<ResearchProject>();
            List<Publication> publications = new List<Publication>();
            List<Thesis> _theses = new List<Thesis>();
            List<Person> person = new List<Person>();
            DateTime? dateTime = null;
            Person? coordinator = null;
            var GroupTest = new
            {
                Id = ResearchGroupId.TryCreate("HCI").Success(),
                ResearchCenterId = 1,
                Name = ResearchGroupName.TryCreate("name1").Success(),
                Description = ResearchGroupDescription.TryCreate("Generic description #1 to do testing").Success(),
                Image = test,
                Start_Date = dateTime,
                _researchArea = area,
                ResearchArea = area.AsReadOnly(),
                _researchProjects = projects,
                ResearchProjects = projects.AsReadOnly(),
                _publications = publications,
                Publications = publications.AsReadOnly(),
                _thesis = _theses,
                Thesis = _theses.AsReadOnly(),
                Coordinator = coordinator,
                _person = person,
                Person = person.AsReadOnly(),
            };
            var Center = new { Id = 1 };


            var options = new DbContextOptionsBuilder<GeneralDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabaseGroup")
                .Options;
            ILogger<GeneralDbContext> logger = null!;
            // Insert seed data into the database using one instance of the context
            byte[] aux = { 1, 1, 1 };
            using (var context = new GeneralDbContext(options, logger))
            {
                context.Groups.Add(new Group(ResearchGroupId.TryCreate("HCI").Success(), 1, ResearchGroupName.TryCreate("name1").Success(),
                    ResearchGroupDescription.TryCreate("Generic description #1 to do testing").Success(), aux, null));
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new GeneralDbContext(options, logger))
            {
                GroupRepository groupRepository = new GroupRepository(context);

                // act
                var group = await groupRepository.GetByIdAsync(GroupIdTest);

                // assert
                group.Should().BeEquivalentTo(GroupTest);

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task AddNewGroupTestAsync()
        {
            var options = new DbContextOptionsBuilder<GeneralDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabaseGroup")
                .Options;
            ILogger<GeneralDbContext> logger = null!;
            // Insert seed data into the database using one instance of the context
            byte[] aux = { 1, 1, 1 };
            using (var context = new GeneralDbContext(options, logger))
            {
                context.SaveChanges();
            }
            using (var context = new GeneralDbContext(options, logger))
            {
                GroupRepository groupRepository = new GroupRepository(context);

                // act
                var group = new Group(ResearchGroupId.TryCreate("HCI").Success(), 1, ResearchGroupName.TryCreate("name1").Success(),
                    ResearchGroupDescription.TryCreate("Generic description #1 to do testing").Success(), aux, null);

                await groupRepository.AddNewGroup(group);
                var _groupTest = groupRepository.GetByIdAsync("HCI");
                // assert
                context.Groups.Should().Contain(group);
                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task SaveGroupAsyncTest()
        {
            var options = new DbContextOptionsBuilder<GeneralDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabaseGroup")
                .Options;
            ILogger<GeneralDbContext> logger = null!;
            // Insert seed data into the database using one instance of the context
            byte[] aux = { 1, 1, 1 };
            using (var context = new GeneralDbContext(options, logger))
            {
                context.Groups.Add(new Group(ResearchGroupId.TryCreate("HCI").Success(), 1, ResearchGroupName.TryCreate("name1").Success(), ResearchGroupDescription.TryCreate("Generic description #1 to do testing").Success(), aux, null));
                context.SaveChanges();
            }
            using (var context = new GeneralDbContext(options, logger))
            {
                GroupRepository groupRepository = new GroupRepository(context);

                // act
                var group = await groupRepository.GetByIdAsync("HCI");
                group!.Name = ResearchGroupName.TryCreate("name1b").Success();
                await groupRepository.SaveAsync(group);

                var _groupTest = await groupRepository.GetByIdAsync("HCI");
                // assert
                group.Should().BeEquivalentTo(_groupTest);
                context.Database.EnsureDeleted();
            }
        }
    }
}
