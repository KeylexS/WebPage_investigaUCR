using Domain.Core.ValueObjects;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.Repositories;
using Application.ResearchGroups.Implementations;
using LanguageExt;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Core.ValueObjects.RequiredString;
using FluentAssertions;
using Domain.Core.Helpers;
using Domain.People.Entities;
using Application.People.Implementations;
using Domain.People.Repositories;
using Application.ResearchGroups;
using LanguageExt.Pipes;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchAreas.Entities;
using Domain.ResearchProjects.Entities;
using Domain.Publications.Entities;
using Domain.ResearchGroups.ValueObjects;
using Domain.Theses.Entities;

//User story: SD-RG-1.5 & TT: PIIB22II02-287 Make unit tests
//US: PIIB22II02-350 SD-RG-1.6 Show the custom image for each groups in research groups list && TT: PIIB22II02-573 Update the Unit test
namespace UnitTesting.Application.ResearchGroups
{
    public class GroupServiceTests
    {
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

        [Fact]
        public async void GroupServiceTestGetGroupsAsync()
        {
            // arrange
            var groupCountTest = 2;

            var mockGroupRepository = new Mock<IGroupRepository>();
            mockGroupRepository.Setup(p => p.GetAllAsync()).Returns(GetTestGroupDTOAsync());

            var groupService = new GroupService(mockGroupRepository.Object);

            // act
            var group = await groupService.GetGroupAsync();

            // assert
            group.Should().HaveCount(groupCountTest);
        }


        //User story SD-RG-1.3 & TT:  PIIB22II02-549 Make unit tests
        public async Task<Group?> GetTestGroupAsync()
        {
            byte[] test = { 1, 1, 1 };
            var testData = new Group(ResearchGroupId.TryCreate("HCI").Success(), 1, ResearchGroupName.TryCreate("name1").Success(), ResearchGroupDescription.TryCreate("Generic description #1 to do testing").Success(), test, null);
            return await Task.FromResult<Group>(testData);
        }
        [Fact]
        public async void GroupServiceTestGetGroupByIdAsync()
        {
            // arrange
            byte[] test = { 1, 1, 1 };
            List<ResearchArea> area = new List<ResearchArea>();
            List<ResearchProject> projects = new List<ResearchProject>();
            List<Publication> publications = new List<Publication>();
            List<Thesis> _theses = new List<Thesis>();
            List<Person> person = new List<Person>();
            var GroupIdTest = ResearchGroupId.TryCreate("HCI").Success();
            DateTime? dateTime = null;
            Person? coordinator = null;
            var personTest = new
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

            var mockGroupRepository = new Mock<IGroupRepository>();
            mockGroupRepository.Setup(p => p.GetByIdAsync(GroupIdTest.ToString())).Returns(GetTestGroupAsync());

            var groupService = new GroupService(mockGroupRepository.Object);

            // act
            var group = await groupService.GetGroupByIdAsync(GroupIdTest.ToString());

            // assert
            group.Should().BeEquivalentTo(personTest);
        }
    }
}
