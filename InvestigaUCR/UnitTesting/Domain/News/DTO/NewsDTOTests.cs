using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.News.DTOs;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchProjects.ValueObjects;
using FluentAssertions;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Core.ValueObjects.RequiredString;

namespace UnitTesting.Domain.News.DTO
{
    public class NewsDTOTests
    {
        [Fact]
        public void NewsDTOTestInstance()
        {
            DateTime myDate = DateTime.Now.Date.Add(new TimeSpan(4, 30, 0));
            DateTime auxDate = myDate;
            var GroupId = ResearchGroupId.TryCreate("CRCUCRCITICESE").Success();
            Group group = null!;
            // arrange
            var newsTest = new { Id = "ESE-1", Title = "Title1", Description = "Generic description", Author = "Robert Montoya",  PublicationDate = myDate};
            // act
            var news = new NewsDTO("ESE-1", "Title1", "Generic description", "Robert Montoya", auxDate, group, null);

            // assert
            news.Should().BeEquivalentTo(newsTest);
        }
    }
}
