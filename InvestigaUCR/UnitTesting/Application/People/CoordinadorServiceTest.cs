using Domain.Core.ValueObjects;
using Domain.People.DTOs;
using Domain.People.Entities;
using Domain.People.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Moq;
using Domain.People.Repositories;
using Application.People;
using Application.People.Implementations;
using System.Xml.Linq;
using LanguageExt;
using Domain.People.Relations;
using Domain.Core.Helpers;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchGroups.ValueObjects;
using Application.Shared.StringManipulation.Implementations;

namespace UnitTesting.Application.People
{
    public class CoordinadorServiceTest
    {
        public async Task<CoordinatorDto> GetTestAllCoordinatorsAsync()
        {
            var testData = new CoordinatorDto("Group1","edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
                RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null);

            return await Task.FromResult<CoordinatorDto>(testData);
        }

        public async Task<Coordinator?> GetTestCoordinatorsAsync()
        {
            var testData = new Coordinator("Group1", "edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
                RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null);

            return await Task.FromResult<Coordinator?>(testData);
        }

        public static async Task<IEnumerable<CoordinatorDto>> GetListCoordinatorTest()
        {
            var testData = new List<CoordinatorDto>
            {
                new CoordinatorDto("Group1","edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
                RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null),
                
                new CoordinatorDto("Group1","edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
                RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null),
                
                new CoordinatorDto("Group1","edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
                RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null)

            }.AsEnumerable();

            return await Task.FromResult<IEnumerable<CoordinatorDto>>(testData);
        }

        [Fact]
        public async void GetAllCoordinatorsAsyncTest()
        {
            // arrange
            var coordinatorCountTest = 3;

            var mockCoordinatorRepository = new Mock<ICoordinatorRepository>();
            mockCoordinatorRepository.Setup(p => p.GetAllCoordinatorsAsync()).Returns(GetListCoordinatorTest());

            var peopleService = new CoordinatorService(mockCoordinatorRepository.Object);

            // act
            var people = await peopleService.GetAllCoordinatorsAsync();

            // assert
            people.Should().HaveCount(coordinatorCountTest);
        }

        [Fact]
        public async void GetCoordinatorByGroupIdAsyncTest()
        {
            // arrange
            var groupId = "Group1";
            var mockCoordinatorRepository = new Mock<ICoordinatorRepository>();
            var coordinatorTest = new
            {
                GroupId = "Group1",
                Id = "edgar.casasola@ecci.ucr.ac.cr",
                Name = RequiredString.TryCreate("Edgar").Success(),
                LastName1 = RequiredString.TryCreate("Casasola").Success(),
                LastName2 = RequiredString.TryCreate("Murillo").Success(),
                HighestDegree = PersonHighestDegree.TryCreate("Dr.").Success(),
                University = RequiredString.TryCreate("Universidad de Costa Rica").Success(),
            };
            mockCoordinatorRepository.Setup(p => p.GetCoordinatorByGroupIdAsync(groupId)).Returns(GetTestCoordinatorsAsync());

            var CoordinatorService = new CoordinatorService(mockCoordinatorRepository.Object);

            // act
            var coordinator = await CoordinatorService.GetCoordinatorByGroupIdAsync(groupId);
            // assert
            coordinator.Should().BeEquivalentTo(coordinatorTest);
        }
    }
}