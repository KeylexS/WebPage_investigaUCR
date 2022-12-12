using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.ResearchProjects.Entities;
using Domain.ResearchProjects.ValueObjects;
using FluentAssertions;
using Domain.ResearchGroups.ValueObjects;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;
using System.Globalization;
using Domain.Theses.Entities;
using Domain.People.Entities;
using Domain.ResearchGroups.Entities;
using Group = Domain.ResearchGroups.Entities.Group;

namespace UnitTesting.Domain.ResearchProjects.Entities
{
    public class ResearchProjectTests
    {
        [Fact]
        public void ResearchProjectsTestEmptyInstance()
        {
            //("CRCUCRCITICESE", "Grupo de investigación en ingeniería de software empírica", 1);
            // arrange
            var researchProjectTest = new {  Start_date = DateTime.Today, End_date = DateTime.Today, Description = "",};

            // act 
            var researchProject = new ResearchProject();

            // assert
            researchProject.Should().BeEquivalentTo(researchProjectTest);
        }

        [Fact]
        public void ResearchProjectsTestInstance()
        {
            // arrange
            var researchProjectTest = new { Id = ResearchProjectId.TryCreate("123-A1-123").Success(), Name = "NombreProyecto1", Start_date = DateTime.Today, End_date = DateTime.Today, Description = "Descripción de proyecto 1", Image = new byte[] { 0x20, 0x20 },};

            // act 
            var researchProject = new ResearchProject(ResearchProjectId.TryCreate("123-A1-123").Success(), "NombreProyecto1", DateTime.Today, DateTime.Today, "Descripción de proyecto 1", new byte[] { 0x20, 0x20 });

            // assert
            researchProject.Should().BeEquivalentTo(researchProjectTest);
        }

        [Fact]
        public void ResearchProjectAddThesis()
        {
            // arrange
            var researchProject = new ResearchProject(ResearchProjectId.TryCreate("123-A1-123").Success(),
                                                      "NombreProyecto1",
                                                      System.DateTime.Now,
                                                      System.DateTime.Now,
                                                      "Descripción de proyecto 1",
                                                      new byte[] { 0x20, 0x20 });
            var list = new List<Person>();
            var thesis = new Thesis("Title1", "type1", 1, System.DateTime.Now, "Description", list);

            // act 
            researchProject.AddThesis(thesis);

            // assert
            researchProject.Theses.Should().Contain(thesis);
        }
    }
}