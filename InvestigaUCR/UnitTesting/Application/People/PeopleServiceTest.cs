using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using FluentAssertions;
using Domain.People.Entities;
using Moq;
using Domain.People.Repositories;
using Application.People;
using Application.People.Implementations;
using System.Xml.Linq;
using LanguageExt;
using Domain.People.Relations;
using Domain.Core.ValueObjects;
using Domain.People.DTOs;
using Domain.Core.Helpers;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchGroups.ValueObjects;
using Application.Shared.StringManipulation.Implementations;
using Domain.People.ValueObjects;
using Domain.ResearchGroups.Entities;
//ID: PIIB22II02-59, US: MC-PL-1.3, task: PIIB22II02-170 Unit test for the feature

namespace UnitTesting.Application.People
{
    public class PeopleServiceTest
    {

        // People list for testing
        public async Task<Person?> GetTestPersonAsync()
        {
            var testData = new Person("edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
                RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null);

            return await Task.FromResult<Person?>(testData);
        }

        [Fact]
        public async void GetPersonByIdTest()
        {
            byte[]? img = null;
            // arrange
            var peopleIdTest = "edgar.casasola@ecci.ucr.ac.cr";
            List<Group> coordinatorGroups = new List<Group>();
            List<Group> researchGroup = new List<Group>();
            var personTest = new
            {
                Id = "edgar.casasola@ecci.ucr.ac.cr",
                Name = RequiredString.TryCreate("Edgar").Success(),
                LastName1 = RequiredString.TryCreate("Casasola").Success(),
                LastName2 = RequiredString.TryCreate("Murillo").Success(),
                HighestDegree = PersonHighestDegree.TryCreate("Dr.").Success(),
                University = RequiredString.TryCreate("Universidad de Costa Rica").Success(),
                ProfilePicture = img,
                CoordinatorGroups = coordinatorGroups,
                ResearchGroup = researchGroup
            };

            var mockPeopleRepository = new Mock<IPeopleRepository>();
            mockPeopleRepository.Setup(p => p.GetByIdAsync(peopleIdTest)).Returns(GetTestPersonAsync());

            var peopleService = new PeopleServices(mockPeopleRepository.Object);

            // act
            var person = await peopleService.GetPersonByIdAsync(peopleIdTest);

            // assert
            person.Should().BeEquivalentTo(personTest);
        }

        // People list for testing
        public static async Task<IEnumerable<Person>?> GetListPeopleTest()
        {
            var testData = new List<Person>
            {
                new Person("edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
                    RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null),

                new Person("edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
                    RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null),

                new Person("edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
                    RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null)
            }.AsEnumerable();

            return await Task.FromResult<IEnumerable<Person>?>(testData);
        }

        [Fact]
        public async void GetPeopleTest()
        {
            // arrange
            var peopleCountTest = 3;

            var mockPeopleRepository = new Mock<IPeopleRepository>();
            mockPeopleRepository.Setup(p => p.GetAllAsync()).Returns(GetListPeopleTest());

            var peopleService = new PeopleServices(mockPeopleRepository.Object);

            // act
            var people = await peopleService.GetPeopleAsync();

            // assert
            people.Should().HaveCount(peopleCountTest);
        }

        // List of groups
        public async Task<IEnumerable<GroupDTO>> GetTestGroupDTOAsync()
        {
            byte[] test = { 1, 1, 1 };
            var testData = new List<GroupDTO>
            {
                new GroupDTO(ResearchGroupId.TryCreate("HCI").Success(), ResearchGroupName.TryCreate("name1").Success(), ResearchGroupDescription.TryCreate("Generic description #1 to do testing").Success(), test),
                new GroupDTO(ResearchGroupId.TryCreate("SP").Success(), ResearchGroupName.TryCreate("name2").Success(), ResearchGroupDescription.TryCreate("Generic description #1 to do testing").Success(), test),
            }.AsEnumerable();
            return await Task.FromResult<IEnumerable<GroupDTO>>(testData);
        }

        //PIIB22II02-503 MC-PL-1.1 Show people from a research group | task: PIIB22II02-617 Unit test for the feature (Application)
        [Fact]
        public async void GetPeopleByGroupTest()
        {
            // arrange
            var groupCountTest = 2;
            var personId = "edgar.casasola@ecci.ucr.ac.cr";

            var mockPeopleRepository = new Mock<IPeopleRepository>();

            mockPeopleRepository.Setup(p => p.GetGroupsByPersonID(personId)).Returns(GetTestGroupDTOAsync());

            var peopleService = new PeopleServices(mockPeopleRepository.Object);

            // act
            var people = await peopleService.GetGroupsByPersonID(personId);

            // assert
            people.Should().HaveCount(groupCountTest);
        }
    }
}
