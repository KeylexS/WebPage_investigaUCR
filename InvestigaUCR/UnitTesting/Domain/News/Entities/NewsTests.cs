using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.ResearchAreas.Entities;
using Domain.ResearchGroups.Entities;
using Domain.News.Entities;
using FluentAssertions;
using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Domain.Core.ValueObjects.RequiredString;
using Domain.ResearchGroups.ValueObjects;
using Domain.People.Entities;
using Domain.People.Relations;
using System.Drawing;

namespace UnitTesting.Domain.News.Entities
{
    /// <summary>
    /// This class in on charge of testing all intances in News entity
    /// </summary>
    public class NewsTests
    {
        [Fact]
        public void NewsTestInstance()
        {
            DateTime myDate = DateTime.Now.Date.Add(new TimeSpan(4, 30, 0));
            Group group = null!;
            // arrange
            var newsTest = new
            {
                Id = "ESE-1",
                Title = "Title1",
                Description = "Generic Description",
                Author = "Robert Montoya",
                PublicationDate = myDate,
                Group = group,
            };

            // act
            DateTime auxDate = DateTime.Now.Date.Add(new TimeSpan(4, 30, 0));
            var news = new GroupNews("ESE-1", "Title1", "Generic Description", "Robert Montoya", auxDate, group, null);

            // assert
            news.Should().BeEquivalentTo(newsTest);
        }

        [Fact]
        public void NewsTestDescription()
        {
            // arrange
            var descriptionTest = "Generic Description";

            // act
            var news = new GroupNews("ESE-1", "Title1", "Generic Description", "Robert Montoya", null, null, null);

            // assert
            news.Description.Should().BeEquivalentTo(descriptionTest);
        }

        [Fact]
        public void NewsTestEmptyInstance()
        {
            // arrange
            String id = null!;
            String title = null!;
            String description = null!;
            String author = null!;
            DateTime? myDate = null!;
            Group group = null!;
            byte[] img = null!;

            var newsTest = new
            {
                Id = id,
                Title = title,
                Description = description,
                Author = author,
                PublicationDate = myDate,
                Group = group,
                Image = img,
            };

            // act
            var news = new GroupNews();

            //assert
            news.Should().BeEquivalentTo(newsTest);
        }
    }
}
