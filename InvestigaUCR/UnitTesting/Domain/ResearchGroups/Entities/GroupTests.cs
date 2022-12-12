using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.ResearchGroups.Entities;
using Domain.ResearchAreas.Entities;
using FluentAssertions;
using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Domain.Core.ValueObjects.RequiredString;
using Domain.ResearchProjects.Entities;
using Domain.Publications.Entities;
using Domain.ResearchGroups.ValueObjects;
using Domain.News.Entities;
using Domain.People.Entities;
using Domain.Theses.Entities;

//User story: SD-RG-1.5 & TT: PIIB22II02-287 Make unit tests
//US: PIIB22II02-350 SD-RG-1.6 Show the custom image for each groups in research groups list && TT: PIIB22II02-573 Update the Unit test
namespace UnitTesting.Domain.ResearchGroups.Entities
{
    public class GroupTests
    {
        [Fact]
        public void GroupTestInstance()
        {
            // arrange
            byte[] test = { 1, 1, 1 };
            List<ResearchArea> area = new List<ResearchArea>();
            List<ResearchProject> projects = new List<ResearchProject>();
            List<Publication> publications = new List<Publication>();
            List<GroupNews> news = new List<GroupNews>();
            List<Thesis> _theses = new List<Thesis>();
            DateTime? testDate = null;
            Person? coordinator = null;
            List<Person> person = new List<Person>();
            var grouptest = new
            {
                Id = ResearchGroupId.TryCreate("HCI").Success(),
                ResearchCenterId = 1,
                Name = ResearchGroupName.TryCreate("Name1").Success(),
                Description = ResearchGroupDescription.TryCreate("Generic Description").Success(),
                Image = test,
                Start_Date = testDate,
                _news = news,
                News = news.AsReadOnly(),
                _groupsAreas = area,
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

            // act 
            byte[] aux = { 1, 1, 1 };
            DateTime? auxDate = null;
            var group = new Group(ResearchGroupId.TryCreate("HCI").Success(), 1, ResearchGroupName.TryCreate("Name1").Success(), ResearchGroupDescription.TryCreate("Generic Description").Success(), aux, auxDate);

            // assert
            grouptest.Should().BeEquivalentTo(group);
        }
    }
}
