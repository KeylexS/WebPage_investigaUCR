using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Domain.People.Entities;
using LanguageExt.Pretty;
using Domain.Core.ValueObjects;
using Domain.People.DTOs;
using Domain.Core.Helpers;
using Domain.People.ValueObjects;
using Domain.ResearchGroups.Entities;
//ID: PIIB22II02-59, US: MC-PL-1.3, task: PIIB22II02-170 Unit test for the feature

namespace UnitTesting.Domain.People.Entities
{
    public class PersonTests
    {

        [Fact]
        public void PeopleTestInstancePerson()
        {
            byte[]? profilePic = { 1, 1, 1 };
            List<Group> coordinatorGroups = new List<Group>();
            List<Group> researchGroup = new List<Group>();
            // arrange
            var personTest = new
            {
                Id = "Email1",
                Name = RequiredString.TryCreate("Marcelo").Success(),
                LastName1 = RequiredString.TryCreate("Jenkins").Success(),
                LastName2 = RequiredString.TryCreate("Coronas").Success(),
                HighestDegree = PersonHighestDegree.TryCreate("Dr.").Success(),
                University = RequiredString.TryCreate("Universidad de Costa Rica").Success(),
                ProfilePicture = profilePic,
                CoordinatorGroups = coordinatorGroups,
                ResearchGroup = researchGroup
            };

            // act 
            var person = new Person("Email1", RequiredString.TryCreate("Marcelo").Success(), RequiredString.TryCreate("Jenkins").Success(), 
                RequiredString.TryCreate("Coronas").Success(), PersonHighestDegree.TryCreate("Dr.").Success(), 
                RequiredString.TryCreate("Universidad de Costa Rica").Success(), profilePic);

            // assert
            person.Should().BeEquivalentTo(personTest);
        }

        [Fact]
        public void PeopleTestInstancePersonDto()
        {
            byte[]? profilePic = { 1, 1, 1 };
            // arrange
            var personTest = new
            {
                Id = "Casa",
                Name = RequiredString.TryCreate("Marcelo").Success(),
                LastName1 = RequiredString.TryCreate("Jenkins").Success(),
                LastName2 = RequiredString.TryCreate("Coronas").Success(),
                HighestDegree = PersonHighestDegree.TryCreate("Dr.").Success(),
                University = RequiredString.TryCreate("Universidad de Costa Rica").Success(),
                ProfilePicture = profilePic
            };

            // act 
            var person = new PersonDto("Casa", RequiredString.TryCreate("Marcelo").Success(), RequiredString.TryCreate("Jenkins").Success(), 
                RequiredString.TryCreate("Coronas").Success(), PersonHighestDegree.TryCreate("Dr.").Success(),
                RequiredString.TryCreate("Universidad de Costa Rica").Success(), profilePic);

            // assert
            person.Should().BeEquivalentTo(personTest);
        }

    }
}
