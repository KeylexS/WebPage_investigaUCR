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
using LanguageExt.Pretty;
using Domain.Core.Helpers;
using System.Xml.Linq;
using Domain.ResearchProjects.Entities;

namespace UnitTesting.Domain.People.Entities
{
    public class CoordinadorTests
    {
    
    [Fact]
    public void CoordinadorTestInstanceCoordinador()
    {
        byte[]? profilePic = { 1, 1, 1 };
        // arrange
        var coordinatorTest = new
        {
            GroupId = "Group1",
            Id = "Email1",
            Name = RequiredString.TryCreate("Marcelo").Success(),
            LastName1 = RequiredString.TryCreate("Jenkins").Success(),
            LastName2 = RequiredString.TryCreate("Coronas").Success(),
            HighestDegree = PersonHighestDegree.TryCreate("Dr.").Success(),
            University = RequiredString.TryCreate("Universidad de Costa Rica").Success(),
            ProfilePicture = profilePic
        };

            // act 
        var coordinator = new Coordinator("Group1", "Email1", RequiredString.TryCreate("Marcelo").Success(), RequiredString.TryCreate("Jenkins").Success(),
                RequiredString.TryCreate("Coronas").Success(), PersonHighestDegree.TryCreate("Dr.").Success(),
                RequiredString.TryCreate("Universidad de Costa Rica").Success(), profilePic);

        // assert
        coordinator.Should().BeEquivalentTo(coordinatorTest);
    }

    [Fact]
    public void CoordinadorTestInstanceCoordinadorDto()
    {
        byte[]? profilePic = { 1, 1, 1 };
        // arrange
        var coordinatorTest = new
        {
            GroupId = "Group0",
            Id = "Email1",
            Name = RequiredString.TryCreate("Marcelo").Success(),
            LastName1 = RequiredString.TryCreate("Jenkins").Success(),
            LastName2 = RequiredString.TryCreate("Coronas").Success(),
            HighestDegree = PersonHighestDegree.TryCreate("Dr.").Success(),
            University = RequiredString.TryCreate("Universidad de Costa Rica").Success(),
            ProfilePicture = profilePic
        };

        // act 
        var coordinator = new Coordinator("Group0", "Email1", RequiredString.TryCreate("Marcelo").Success(), RequiredString.TryCreate("Jenkins").Success(),
                RequiredString.TryCreate("Coronas").Success(), PersonHighestDegree.TryCreate("Dr.").Success(),
                RequiredString.TryCreate("Universidad de Costa Rica").Success(), profilePic);

        // assert
        coordinator.Should().BeEquivalentTo(coordinatorTest);
    }

}
}