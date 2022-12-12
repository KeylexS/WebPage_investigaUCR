using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using FluentAssertions;
using Domain.People.Relations;
using LanguageExt.Pretty;
using Domain.People.Entities;
using Domain.Publications.Entities;

//PIIB22II02-525 MC-PL-2.8 Show research groups associated with a person | task: PIIB22II02-616 Unit test for the feature (Domain)

namespace UnitTesting.Domain.People.Relations
{
    public class AuthorTest
    {
        [Fact]
        public void AuthorTestInstance()
        {
            Person? person = new();
            Publication? publication = new();
            // arrange
            var authorTest = new
            {
                DOI = "doi1",
                Id = "email1",
                Order = 0,
                Publication = publication,
                People = person
            };

            // act 
            var author = new Author("doi1", "email1", 0, publication, person);

            // assert
            author.Should().BeEquivalentTo(authorTest);
        }

        [Fact]
        public void AuthorEmptyTestInstance()
        {
            Person? person = null;
            Publication? publication = null;
            // arrange
            var authorTest = new
            {
                DOI = "",
                Id = "",
                Order = 0,
                Publication = publication,
                People = person
            };

            // act 
            var author = new Author();

            // assert
            author.Should().BeEquivalentTo(authorTest);
        }
    }
}
