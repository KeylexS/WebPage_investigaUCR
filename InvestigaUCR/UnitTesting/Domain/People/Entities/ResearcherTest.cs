using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.People.Entities;
using Domain.People.ValueObjects;
using FluentAssertions;

namespace UnitTesting.Domain.People.Entities
{
    public class ResearcherTest
    {
        [Fact]
        public void ResearcherTestInstanceResearcher()
        {
            byte[]? profilePic = { 1, 1, 1 };
            // arrange
            var researcherTest = new
            {
                GroupId = "Grupo1",
                Id = "Email1",
                Name = RequiredString.TryCreate("Marcelo").Success(),
                LastName1 = RequiredString.TryCreate("Jenkins").Success(),
                LastName2 = RequiredString.TryCreate("Coronas").Success(),
                HighestDegree = PersonHighestDegree.TryCreate("Dr.").Success(),
                University = RequiredString.TryCreate("Universidad de Costa Rica").Success(),
                ProfilePicture = profilePic
            };

            // act 
            var researcher = new Researcher("Grupo1", "Email1", RequiredString.TryCreate("Marcelo").Success(),
                RequiredString.TryCreate("Jenkins").Success(),
                RequiredString.TryCreate("Coronas").Success(), PersonHighestDegree.TryCreate("Dr.").Success(),
                RequiredString.TryCreate("Universidad de Costa Rica").Success(), profilePic);

            // assert
            researcher.Should().BeEquivalentTo(researcherTest);
        }

        [Fact]
        public void ResearcherTestEmptyInstance()
        {
            byte[]? profilePic = null!;
            // arrange
            var researcherTest = new
            {
                GroupId = "",
                Id = "",
                ProfilePicture = profilePic
            };

            // act 
            var researcher = new Researcher();

            // assert
            researcher.Should().BeEquivalentTo(researcherTest);
        }
    }
}
