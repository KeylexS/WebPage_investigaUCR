using Domain.People.Entities;
using Infrastructure.People.Context.Implementation;
using Infrastructure.People.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Domain.People.Relations;
using Domain.ResearchGroups.DTOs;
using Infrastructure.ResearchGroups.Repositories;
using Domain.ResearchGroups.Entities;
using Domain.Core.ValueObjects;
using Domain.People.DTOs;
using Domain.Core.Helpers;
using Domain.ResearchGroups.ValueObjects;
using System.Runtime.Intrinsics.X86;
using Domain.People.ValueObjects;
using Infrastructure;

//ID: PIIB22II02-59, US: MC-PL-1.3, task: PIIB22II02-170 Unit test for the feature

namespace UnitTesting.Infrastructure.People.Repositories
{
    public class PeopleRepositoryTest
    {
        [Fact]
        public async void GetPersonByIdTest()
        {
            // arrange
            byte[]? img = null;
            var peopleIdTest = "edgar.casasola@ecci.ucr.ac.cr7";
            List<Group> researchGroup = null!;
            List<Group> coordinatorGroups = null!;
            var personTest = new {
                Id = "edgar.casasola@ecci.ucr.ac.cr7",
                Name = RequiredString.TryCreate("Edgar").Success(),
                LastName1 = RequiredString.TryCreate("Casasola").Success(),
                LastName2 = RequiredString.TryCreate("Murillo").Success(),
                HighestDegree = PersonHighestDegree.TryCreate("Dr.").Success(),
                University = RequiredString.TryCreate("Universidad de Costa Rica").Success(),
                ProfilePicture = img,
                CoordinatorGroups = coordinatorGroups,
                ResearchGroup = researchGroup
            };

            var options = new DbContextOptionsBuilder<GeneralDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabasePeopleRepositoryTestGetByIdAsync")
                .Options;
            ILogger<GeneralDbContext> logger = null!;

            // Insert seed data into the database using one instance of the context
            using (var context = new GeneralDbContext(options, logger))
            {
                context.People.Add(new Person("edgar.casasola@ecci.ucr.ac.cr7", RequiredString.TryCreate("Edgar").Success(),
                    RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null));
                context.People.Add(new Person("edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
                    RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null));

                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new GeneralDbContext(options, logger))
            {
                PeopleRepository peopleRepository = new PeopleRepository(context);

                // act
                var person = await peopleRepository.GetByIdAsync(peopleIdTest);

                // assert
                person.Should().BeEquivalentTo(personTest);

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async void GetAllPeopleTest()
        {
            // arrange
            var peopleCountTest = 2;

            var options = new DbContextOptionsBuilder<GeneralDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabasePeopleRepositoryTestGetAllAsync")
                .Options;
            ILogger<GeneralDbContext> logger = null!;

            // Insert seed data into the database using one instance of the context
            using (var context = new GeneralDbContext(options, logger))
            {
                context.People.Add(new Person("edgar.casasola@ecci.ucr.ac.cr7", RequiredString.TryCreate("Edgar").Success(),
                    RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null));
                context.People.Add(new Person("edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
                    RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null));

                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new GeneralDbContext(options, logger))
            {
                PeopleRepository peopleRepository = new PeopleRepository(context);

                // act
                var people = await peopleRepository.GetAllAsync();

                // assert
                people.Should().HaveCount(peopleCountTest);

                context.Database.EnsureDeleted();
            }
        }

        //PIIB22II02-525 MC-PL-2.8 Show research groups associated with a person | task: PIIB22II02-616 Unit test for the feature (Infrastructure)
        [Fact]
        public async void PeopleRepositoryTestGetGroupsByPersonID()
        {
            // arrange
            var peopleCountTest = 2;  // 2 people related with the group

            var options = new DbContextOptionsBuilder<GeneralDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabaseGetGroupsByPersonID")
                .Options;
            ILogger<GeneralDbContext> logger = null!;

            // Insert seed data into the database using one instance of the context
            using (var context = new GeneralDbContext(options, logger))
            {
                context.Composed_by.Add(new Composedby("researchGroupId1", "email1"));  // to fill (no count)
                context.Composed_by.Add(new Composedby("researchGroupId2", "email1"));  // 1 group associated
                context.Composed_by.Add(new Composedby("researchGroupId3", "email2"));  // 2 groups associated
                byte[] test = { 1, 1, 1 };
                context.Groups.Add(new Group(ResearchGroupId.TryCreate("researchGroupId1").Success(), 1,
                    ResearchGroupName.TryCreate("researchGroupName1").Success(),
                    ResearchGroupDescription.TryCreate("Description1...").Success(), test, null));  //group
                context.Groups.Add(new Group(ResearchGroupId.TryCreate("researchGroupId2").Success(), 1,
                    ResearchGroupName.TryCreate("researchGroupName2").Success(),
                    ResearchGroupDescription.TryCreate("Description2...").Success(), test, null));  //group
                context.Groups.Add(new Group(ResearchGroupId.TryCreate("researchGroupId3").Success(), 2,
                    ResearchGroupName.TryCreate("researchGroupName2").Success(),
                    ResearchGroupDescription.TryCreate("Description2...").Success(), test, null));  //group
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new GeneralDbContext(options, logger))
            {
                PeopleRepository peopleRepository = new PeopleRepository(context);

                // act
                var people = await peopleRepository.GetGroupsByPersonID("email1");

                // assert
                people.Should().HaveCount(peopleCountTest);

                context.Database.EnsureDeleted();
            }
        }
    }
}

