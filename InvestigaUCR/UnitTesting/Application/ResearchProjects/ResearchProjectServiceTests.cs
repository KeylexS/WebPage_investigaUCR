using Application.ResearchProjects.Implementations;
using Domain.Core.Helpers;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchProjects.Entities;
using Domain.ResearchProjects.Repositories;
using Domain.ResearchProjects.ValueObjects;
using FluentAssertions;
using Moq;

namespace UnitTesting.Application.ResearchProjects
{
    // Unit tests for research project service
    public class ResearchProjectsServiceTests
    {
        public async Task<IEnumerable<ResearchProject>> GetTestResearchProjectsAsync()
        {
            System.DateTime date1 = new System.DateTime(2015, 3, 10, 2, 15, 10);
            System.DateTime date2 = new System.DateTime(2015, 7, 15, 6, 30, 20);
            var testData = new List<ResearchProject>
            {
                new ResearchProject(ResearchProjectId.TryCreate("123-A1-123").Success(), "Name1", date1, date2, "description1", null),
                new ResearchProject(ResearchProjectId.TryCreate("123-A2-123").Success(), "Name2", date2, date1, "description2",  null),
            }.AsEnumerable();
            return await Task.FromResult<IEnumerable<ResearchProject>>(testData);
        }

        [Fact]
        public async void ResearchProjectServiceTestGetResearchProjectsAsync()
        {
            // arrange
            var ResearchProjectsCountTest = 2;

            var mockResearchProjectsRepository = new Mock<IResearchProjectsRepository>();
            mockResearchProjectsRepository.Setup(p => p.GetAllAsync()).Returns(GetTestResearchProjectsAsync());

            var researchProjectsService = new ResearchProjectsService(mockResearchProjectsRepository.Object);

            // act
            var researchProjects = await researchProjectsService.GetResearchProjectsAsync();

            // assert
            researchProjects.Should().HaveCount(ResearchProjectsCountTest);
        }

        public async Task<ResearchProject?> GetTestResearchProjectsByIdAsync()
        {
            System.DateTime date1 = new System.DateTime(2015, 3, 10, 2, 15, 10);
            System.DateTime date2 = new System.DateTime(2015, 7, 15, 6, 30, 20);
            var testData = new ResearchProject(ResearchProjectId.TryCreate("123-A1-123").Success(), "Name1", date1, date2, "description1", null);
            return await Task.FromResult<ResearchProject?>(testData);
        }

        [Fact]
        public async void ResearchProjectServiceTestGetResearchProjectByIdAsync()
        {
            // arrange
            var researchProjectsIdTest = "123-A1-123";
            System.DateTime date1 = new System.DateTime(2015, 3, 10, 2, 15, 10);
            System.DateTime date2 = new System.DateTime(2015, 7, 15, 6, 30, 20);
            var researchProjectTest = new { Id = ResearchProjectId.TryCreate("123-A1-123").Success(), Name = "Name1", Start_date = date1, End_date = date2, Description = "description1" };

            var mockResearchProjectsRepository = new Mock<IResearchProjectsRepository>();
            mockResearchProjectsRepository.Setup(p => p.GetByIdAsync(researchProjectsIdTest)).Returns(GetTestResearchProjectsByIdAsync());

            var researchProjectService = new ResearchProjectsService(mockResearchProjectsRepository.Object);

            // act
            var researchProject = await researchProjectService.GetResearchProjectByIdAsync(researchProjectsIdTest);

            // assert
            researchProject.Should().BeEquivalentTo(researchProjectTest);
        }

        [Fact]
        public async void GetFilteredProjectsAsyncName()
        {
            // arrange
            var filterdResearchProjectsCountTest = 2;
            var mockResearchProjectsRepository = new Mock<IResearchProjectsRepository>();
            var researchProjectsService = new ResearchProjectsService(mockResearchProjectsRepository.Object);
            var researchProjects = await GetTestResearchProjectsAsync();
            var testSearchText = "Name";

            // act
            var filteredResearchProjects = researchProjectsService.GetFilteredResearchProjects(testSearchText, researchProjects);

            // assert
            filteredResearchProjects.Should().HaveCount(filterdResearchProjectsCountTest);
        }

        [Fact]
        public async void GetFilteredProjectsAsyncId()
        {
            // arrange
            var filterdResearchProjectsCountTest = 2;
            var mockResearchProjectsRepository = new Mock<IResearchProjectsRepository>();
            var researchProjectsService = new ResearchProjectsService(mockResearchProjectsRepository.Object);
            var researchProjects = await GetTestResearchProjectsAsync();
            var testSearchText = "123";

            // act
            var filteredResearchProjects = researchProjectsService.GetFilteredResearchProjects(testSearchText, researchProjects);

            // assert
            filteredResearchProjects.Should().HaveCount(filterdResearchProjectsCountTest);
        }

        [Fact]
        public async void GetFilteredProjectsAsyncDate()
        {
            // arrange
            var filterdResearchProjectsCountTest = 2;
            var mockResearchProjectsRepository = new Mock<IResearchProjectsRepository>();
            var researchProjectsService = new ResearchProjectsService(mockResearchProjectsRepository.Object);
            var researchProjects = await GetTestResearchProjectsAsync();
            var testSearchText = "2015";

            // act
            var filteredResearchProjects = researchProjectsService.GetFilteredResearchProjects(testSearchText, researchProjects);

            // assert
            filteredResearchProjects.Should().HaveCount(filterdResearchProjectsCountTest);
        }

    }
}
