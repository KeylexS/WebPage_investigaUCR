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

namespace UnitTesting.Domain.ResearchProjectsMethods
{
    public class MethodsTests
    {
        [Fact]
        public void getFormatedStartDate()
        { 
            // arrange
            var start_DateUnformated = new DateTime(2008, 3, 1, 7, 0, 0);
            var start_DateFormated = "01 de marzo del 2008";
            var id = ResearchProjectId.TryCreate("101-01-010").Success();

            // act 
            var test = new ResearchProject(id, "F", start_DateUnformated, DateTime.Today, "", null);

            // assert
            test.getFormatedStartDate().Should().BeEquivalentTo(start_DateFormated);
        }

        [Fact]
        public void getFormatedEndDate()
        {
            // arrange
            var end_DateUnformated = new DateTime(2030, 3, 1, 7, 0, 0);
            var end_DateFormated = "01 de marzo del 2030";
            var id = ResearchProjectId.TryCreate("101-01-010").Success();

            // act 
            var test = new ResearchProject(id, "F", DateTime.Today, end_DateUnformated, "", null);

            // assert
            test.getFormatedEndDate().Should().BeEquivalentTo(end_DateFormated);
        }

        [Fact]
        public void getEndedStatus()
        {
            // arrange
            var start_Date = new DateTime(2008, 3, 1, 7, 0, 0);
            var endedStatus = "Finalizado";
            var id = ResearchProjectId.TryCreate("101-01-010").Success();

            // act 
            var test = new ResearchProject(id, "F", start_Date, DateTime.Today, "", null);

            // assert
            test.getStatus().Should().BeEquivalentTo(endedStatus);
        }

        [Fact]
        public void getInProcessStatus()
        {
            // arrange
            var end_Date = new DateTime(2030, 3, 1, 7, 0, 0);
            var inProcessStatus = "En proceso";
            var id = ResearchProjectId.TryCreate("101-01-010").Success();

            // act 
            var test = new ResearchProject(id, "F", DateTime.Today, end_Date, "", null);

            // assert
            test.getStatus().Should().BeEquivalentTo(inProcessStatus);
        }

        [Fact]
        public void getEmptyDescription()
        {
            // arrange
            var description = "No hay descripción disponible";
            var id = ResearchProjectId.TryCreate("101-01-010").Success();

            // act 
            var test = new ResearchProject(id, "F", DateTime.Today, DateTime.Today, "", null);

            // assert
            test.getDescription().Should().BeEquivalentTo(description);
        }

        [Fact]
        public void getDescription()
        {
            // arrange
            var description = "Esta es una descripcion de prueba";
            var id = ResearchProjectId.TryCreate("101-01-010").Success();

            // act 
            var test = new ResearchProject(id, "F", DateTime.Today, DateTime.Today, "Esta es una descripcion de prueba", null);

            // assert
            test.getDescription().Should().BeEquivalentTo(description);
        }

    }
}
