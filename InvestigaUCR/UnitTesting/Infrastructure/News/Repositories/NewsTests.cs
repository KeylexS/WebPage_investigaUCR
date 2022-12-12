using Microsoft.EntityFrameworkCore;
using Moq;
using Infrastructure.News;
using Domain.News.Entities;
using Domain.News.DTOs;
using Infrastructure.News.Repositories;
using Xunit;
using FluentAssertions;
using Domain.News.Repositories;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging;
using Domain.ResearchGroups.ValueObjects;
using Domain.Core.Helpers;
using Domain.ResearchGroups.Entities;
using System.Text.RegularExpressions;
using Group = Domain.ResearchGroups.Entities.Group;
using Infrastructure;

namespace UnitTesting.Infraestructure.News
{
    public class NewsRepositoryTests
    {
        [Fact]
        public async void NewsRepositoryTestGetAllAsync()
        {
            // arrange
            var newsCountTest = 2;

            ILogger<GeneralDbContext> logger = null!;
            var options = new DbContextOptionsBuilder<GeneralDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;
            using (var context = new GeneralDbContext(options, logger))
            {
                DateTime date1 = DateTime.Now.Date.Add(new TimeSpan(4, 30, 0));
                DateTime date2 = DateTime.Now.Date.Add(new TimeSpan(2, 20, 0));
                
                context.News.Add(new GroupNews("ESE-1", "Title1", "description1", "author1", date1, null, null));
                context.News.Add(new GroupNews("ESE-2", "Title2", "description2", "author2", date2, null, null));
                context.SaveChanges();
            }

            using (var context = new GeneralDbContext(options, logger))
            {
                NewsRepository newsRepository = new NewsRepository(context);

                // act
                var news = await newsRepository.GetAllAsync();

                // assert
                news.Should().HaveCount(newsCountTest);

                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async void NewsRepositoryTestGetByIdAsync()
        {
            // arrange
            string newsIdTest = "ESE-1";
            System.DateTime date1 = new System.DateTime(2015, 3, 10, 2, 15, 10);
            System.DateTime date2 = new System.DateTime(2015, 7, 15, 6, 30, 20);
            Group group = null!;
            var newsTest = new { Id = "ESE-1", Title = "Title1", Description = "description1", Author = "author1", PublicationDate = date1};;


            var options = new DbContextOptionsBuilder<GeneralDbContext>()
                .UseInMemoryDatabase(databaseName: "xInMemoryDatabase")
                .Options;
            ILogger<GeneralDbContext> logger = null!;
            // Insert seed data into the database using one instance of the context
            using (var context = new GeneralDbContext(options, logger))
            {
                context.News.Add(new GroupNews("ESE-1", "Title1", "description1", "author1", date1, null, null));
                context.News.Add(new GroupNews("ESE-2", "Title2", "description2", "author2", date2, null, null));
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new GeneralDbContext(options, logger))
            {
                NewsRepository newsRepository = new NewsRepository(context);

                // act
                var news = await newsRepository.GetByIdAsync(newsIdTest);

                // assert
                news.Should().BeEquivalentTo(newsTest);

                context.Database.EnsureDeleted();
            }
        }
    }
}
