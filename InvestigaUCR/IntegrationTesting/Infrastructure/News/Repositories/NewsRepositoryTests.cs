using Domain.News.Repositories;
using Infrastructure.News.Repositories;
using Infrastructure.News;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FluentAssertions;
using Domain.ResearchGroups.Repositories;
using Infrastructure.ResearchGroups.Repositories;
using Infrastructure.ResearchGroups;
using Infrastructure;

namespace IntegrationTesting.Infrastructure.News.Repositories
{
    public class NewsRepositoryTests
    {
        [Fact]
        public async Task NewsRepositoryGetAllAsyncTest()
        {
            //arrange
            var newsCount = 4;

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<INewsRepository, NewsRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<INewsRepository>();

            var news = await repository.GetAllAsync();

            news.Should().HaveCount(newsCount);
        }

        [Fact]
        public async Task NewsRepositoryGetByIdAsyncTest()
        {
            var newsId = "CITIC-1";
            var title = "CITIC RECIBIÓ LA VISITA DEL PROFESOR JOÃO VIDAL CARVALHO DEL POLITÉCNICO DE PORTO, PORTUGAL";

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<INewsRepository, NewsRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<INewsRepository>();

            var news = await repository.GetByIdAsync(newsId);

            news!.Title.Should().Be(title);
        }
    }
}
