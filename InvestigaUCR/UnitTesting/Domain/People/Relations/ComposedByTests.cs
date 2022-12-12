using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using FluentAssertions;
using Domain.People.Relations;
using LanguageExt.Pretty;

//PIIB22II02-525 MC-PL-2.8 Show research groups associated with a person | task: PIIB22II02-616 Unit test for the feature (Domain)

namespace UnitTesting.Domain.People.Relations
{
    public class ComposedByTests
    {
        [Fact]
        public void ComposedByTestInstance()
        {
            // arrange
            var personTest = new
            {
                researchGroupID = "researchGroupId",
                personalIdentification = "email1",
            };

            // act 
            var person = new Composedby("researchGroupId", "email1");

            // assert
            person.Should().BeEquivalentTo(personTest);
        }

        [Fact]
        public void ComposedByEmptyTestInstance()
        {
            // arrange
            var personTest = new
            {
                researchGroupID = "",
                personalIdentification = "",
            };

            // act 
            var person = new Composedby();

            // assert
            person.Should().BeEquivalentTo(personTest);
        }
    }
}
