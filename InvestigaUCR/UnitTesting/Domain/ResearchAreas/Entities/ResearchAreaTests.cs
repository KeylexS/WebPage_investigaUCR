using Domain.Core.Helpers;
using Domain.Publications.Entities;
using Domain.ResearchAreas.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchProjects.Entities;
using FluentAssertions;
using LanguageExt.UnitsOfMeasure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnitTesting.Domain.ResearchAreas.Entities
{
    public class ResearchAreaTests
    {
        [Fact]
        public void researchAreaInstance()
        {
            List<ResearchProject> projects = new List<ResearchProject>();
            List<Group> groups = new List<Group>();
            var ResearchAreaTest = new { Id = 1, Name = "prueba1", Description = "Prueba1", _researchGroup = groups, ResearchGroup = groups.AsReadOnly(), _projects = projects, Projects = projects.AsReadOnly() };

            ResearchArea area = new ResearchArea(1, "prueba1", "Prueba1");
            area.Should().BeEquivalentTo(ResearchAreaTest);
        }

        [Fact]
        public void ResearchAreaEmptyInstance()
        {
            int id = 0;
            string name = "";
            string description = "";
            List<ResearchProject> projects = null!;
            List<Group> groups = null!;
            var ResearchAreaTest = new { Id = id, Name = name, Description = description, _researchGroup = groups, _projects = projects};

            ResearchArea area = new();
            area.Should().BeEquivalentTo(ResearchAreaTest);
        }

        [Fact]
        public void ResearchAreaAddGroup()
        {
            ResearchArea area = new ResearchArea(1, "prueba1", "Prueba1");
            Group group = new Group(ResearchGroupId.TryCreate("HCB").Success(),1, ResearchGroupName.TryCreate("Prueba").Success(), ResearchGroupDescription.TryCreate("Prueba").Success(), null, null);

            area.addGroupToReseachArea(group);
            var groupTest = area.ResearchGroup.Single();

            area.ResearchGroup.Should().HaveCount(1);
            groupTest.Should().BeEquivalentTo(group);          
        }
    }
}
