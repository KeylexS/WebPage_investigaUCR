using Application.ResearchProjects.Implementations;
using Domain.Core.Helpers;
using Domain.ResearchProjects.Entities;
using Domain.ResearchProjects.Repositories;
using Domain.ResearchProjects.ValueObjects;
using FluentAssertions;
using Moq;
using Domain.People.Entities;
using LanguageExt;
using Domain.Core.ValueObjects;
using Domain.People.ValueObjects;
namespace UnitTesting.Application.ResearchProjects
{
    public class CollaborateServiceTest
    {
        public async Task<IEnumerable<Collaborate>> GetCollaborateAsync()
        {
            System.DateTime date1 = new System.DateTime(2015, 3, 10, 2, 15, 10);
            System.DateTime date2 = new System.DateTime(2015, 7, 15, 6, 30, 20);
            ResearchProject project1 = new ResearchProject(ResearchProjectId.TryCreate("123-A1-123").Success(), "Name1", date1, date2, "description1", null);
            ResearchProject project2 = new ResearchProject(ResearchProjectId.TryCreate("123-A2-123").Success(), "Name2", date2, date1, "description2", null);
            var person1 = new Person("edgar.casasola@ecci.ucr.ac.cr", RequiredString.TryCreate("Edgar").Success(),
            RequiredString.TryCreate("Casasola").Success(), RequiredString.TryCreate("Murillo").Success(),
            PersonHighestDegree.TryCreate("Dr.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null);

            var testData = new List<Collaborate>
            {
                new Collaborate(project1.Id,project1,person1.Id,person1,1),
                new Collaborate(project2.Id,project2,person1.Id,person1,1),
            }.AsEnumerable();
            return await Task.FromResult<IEnumerable<Collaborate>>(testData);
        }
        [Fact]
        public async void TestGetCollaborationsAsync()
        {
            // arrange
            var CollaborationsCountTest = 2;

            var mockCollaborateRepository = new Mock<ICollaborateRepository>();
            mockCollaborateRepository.Setup(p => p.GetAllCollabsAsync()).Returns(GetCollaborateAsync());

            var collaborateService = new CollaborateService(mockCollaborateRepository.Object);

            // act
            var collaborations = await collaborateService.GetAllCollabsAsync();

            // assert
            collaborations.Should().HaveCount(CollaborationsCountTest);
        }
    }
}