using Application.News;
using Application.News.Implementations;
using Domain.News.Entities;
using Domain.News.Repositories;
using Domain.News.DTOs;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Domain.ResearchGroups.ValueObjects;
using Domain.Core.Helpers;
using Domain.ResearchGroups.Entities;

namespace UnitTesting.Application.News
{
    public class NewsServiceTests
    {
        public async Task<IEnumerable<NewsDTO>> GetTestNewsAsync()
        {
            DateTime date1 = DateTime.Now.Date.Add(new TimeSpan(4, 30, 0));
            DateTime date2 = DateTime.Now.Date.Add(new TimeSpan(2, 20, 0));
            var GroupId = ResearchGroupId.TryCreate("CRCUCRCITICESE").Success();
            Group? group = null!;
            var testData = new List<NewsDTO>
            {
                new NewsDTO("ESE-1", "Title1", "description1", "author1", date1, group, null),
                new NewsDTO("ESE-2", "Title2", "description2", "author1", date2, group, null),
            }.AsEnumerable();
            return await Task.FromResult<IEnumerable<NewsDTO>>(testData);
        }

        [Fact]
        public async void ServiceTestGetNewsAsync()
        {
            // arrange
            var NewsCountTest = 2;

            var mockNewsRepository = new Mock<INewsRepository>();
            mockNewsRepository.Setup(p => p.GetAllAsync()).Returns(GetTestNewsAsync());

            var newsService = new NewsService(mockNewsRepository.Object);

            // act
            var news = await newsService.GetNewsAsync();

            // assert
            news.Should().HaveCount(NewsCountTest);
        }

        public async Task<GroupNews?> GetTestNewsByIdAsync()
        {
            DateTime date1 = DateTime.Now.Date.Add(new TimeSpan(4, 30, 0));
            Group group = null!;

            var GroupId = ResearchGroupId.TryCreate("CRCUCRCITICESE").Success();
            var testData = new GroupNews("ESE-1", "Title1", "description1", "author1", date1, group, null);
            return await Task.FromResult<GroupNews?>(testData);
        }

        [Fact]
        public async void NewsServiceTestGetNewsByIdAsync()
        {
            // arrange
            var newsIdTest = "ESE-1";
            DateTime date1 = DateTime.Now.Date.Add(new TimeSpan(4, 30, 0));
            DateTime date2 = DateTime.Now.Date.Add(new TimeSpan(2, 20, 0));

            var GroupId = ResearchGroupId.TryCreate("CRCUCRCITICESE").Success();
            var newsTest = new { Id = "ESE-1", Title = "Title1", Description = "description1", Author = "author1", PublicationDate = date1};

            var mockNewsRepository = new Mock<INewsRepository>();
            mockNewsRepository.Setup(p => p.GetByIdAsync(newsIdTest)).Returns(GetTestNewsByIdAsync());

            var newsService = new NewsService(mockNewsRepository.Object);

            // act
            var news = await newsService.GetNewsByIdAsync(newsIdTest);

            // assert
            news.Should().BeEquivalentTo(newsTest);
        }
    }
}
