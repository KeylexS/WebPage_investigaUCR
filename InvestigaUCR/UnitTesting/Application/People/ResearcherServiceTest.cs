using Application.People.Implementations;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.People.DTOs;
using Domain.People.Entities;
using Domain.People.Repositories;
using Domain.People.ValueObjects;
using FluentAssertions;
using Moq;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Application.People
{
    public class ResearcherServiceTest
    {
        public static async Task<IEnumerable<ResearcherDto>> GetListResearcherTestByGroup()
        {
            var testData = new List<ResearcherDto>
            {
                new ResearcherDto("Grupo1", "email1", RequiredString.TryCreate("Edgar").Success(),
                    RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null),

                new ResearcherDto("Grupo1", "email2", RequiredString.TryCreate("Name1").Success(),
                    RequiredString.TryCreate("Lastname1_1").Success(), RequiredString.TryCreate("Lastname2_1").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null),
            }.AsEnumerable();

            return await Task.FromResult<IEnumerable<ResearcherDto>>(testData);
        }

        public static async Task<IEnumerable<ResearcherDto>> GetListResearcherTest()
        {
            var testData = new List<ResearcherDto>
            {
                new ResearcherDto("Grupo1", "email1", RequiredString.TryCreate("Edgar").Success(),
                    RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null),

                new ResearcherDto("Grupo1", "email2", RequiredString.TryCreate("Name1").Success(),
                    RequiredString.TryCreate("Lastname1_1").Success(), RequiredString.TryCreate("Lastname2_1").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null),

                new ResearcherDto("Grupo2", "email3", RequiredString.TryCreate("Name2").Success(),
                    RequiredString.TryCreate("Lastname1_2").Success(), RequiredString.TryCreate("Lastname2_2").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null),

                new ResearcherDto("Grupo3", "email4", RequiredString.TryCreate("Name3").Success(),
                    RequiredString.TryCreate("Lastname1_3").Success(), RequiredString.TryCreate("Lastname2_3").Success(),
                    PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null)
            }.AsEnumerable();

            return await Task.FromResult<IEnumerable<ResearcherDto>>(testData);
        }

        [Fact]
        public async void GetReasearcherByGroupIdTest()
        {
            // arrange
            var researcherCountTest = 2;
            var groupIdTest = "Grupo1";

            var mockResearcherRepository = new Mock<IResearcherRepository>();
            mockResearcherRepository.Setup(p => p.GetResearchersByGroupIdAsync(groupIdTest)).Returns(GetListResearcherTestByGroup());

            var researcherService = new ResearcherServices(mockResearcherRepository.Object);

            // act
            var person = await researcherService.GetReseachersByGroupIdAsync(groupIdTest);

            // assert
            person.Should().HaveCount(researcherCountTest);
        }

        [Fact]
        public async void GetAllResearchersAsyncTest()
        {
            // arrange
            var researcherCountTest = 4;

            var mockResearcherRepository = new Mock<IResearcherRepository>();
            mockResearcherRepository.Setup(p => p.GetAllResearchersAsync()).Returns(GetListResearcherTest());

            var researcherService = new ResearcherServices(mockResearcherRepository.Object);

            // act
            var person = await researcherService.GetAllResearchersAsync();

            // assert
            person.Should().HaveCount(researcherCountTest);
        }
    }
}
