using Application.ResearchAreas.Implementations;
using Domain.ResearchAreas.Entities;
using Domain.ResearchAreas.Repositories;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Application.ResearchAreas
{
    public class ResearchAreaServiceTests
    {
        public async Task<IEnumerable<ResearchArea>> GetTestResearchAreaAsync()
        {
            byte[] test = { 1, 1, 1 };
            var testData = new List<ResearchArea>
            {
                new ResearchArea(1, "name1", "Generic description #1 to do testing"),
                new ResearchArea(1, "name2", "Generic description #2 to do testing"),
            }.AsEnumerable();
            return await Task.FromResult<IEnumerable<ResearchArea>>(testData);
        }

        [Fact]
        public async void ResearchAreaServiceTestGetAreasAsync()
        {
            // arrange
            var areasCountTest = 2;

            var mockAreaRepository = new Mock<IResearchAreasRepository>();
            mockAreaRepository.Setup(p => p.GetAllAsync()).Returns(GetTestResearchAreaAsync());

            var areaService = new ResearchAreasService(mockAreaRepository.Object);

            // act
            var areas = await areaService.GetResearchAreaAsync();

            // assert
            areas.Should().HaveCount(areasCountTest);
        }

        public async Task<ResearchArea?> GetTestAreaAsync()
        {
            var testData = new ResearchArea(1, "name1", "Generic description #1 to do testing");
            return await Task.FromResult<ResearchArea>(testData);
        }

        [Fact]
        public async void ResearchAreaServiceTestGetResearchAreaByIdAsync()
        {
            List<Group> groups = new List<Group>();
            List<ResearchProject> projects = new List<ResearchProject>();
            // arrange
            var areaTest = new
            {
                Id = 1,
                Name = "name1",
                Description = "Generic description #1 to do testing",
                _researchGroup = groups,
                ResearchGroup = groups.AsReadOnly(),
                _projects = projects,
                Projects = projects.AsReadOnly()
            };

            var mockAreaRepository = new Mock<IResearchAreasRepository>();
            mockAreaRepository.Setup(p => p.GetByIdAsync(areaTest.Id.ToString())).Returns(GetTestAreaAsync());

            var areService = new ResearchAreasService(mockAreaRepository.Object);

            // act
            var group = await areService.GetResearchAreaByIdAsync(areaTest.Id.ToString());

            // assert
            group.Should().BeEquivalentTo(areaTest);
        }
    }
}
