using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.People.DTOs;
using Domain.People.Repositories;
using Domain.People.ValueObjects;
using FluentAssertions;
using Infrastructure.People.Context.Implementation;
using Infrastructure.People.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting.Infrastructure.People.Repositories
{
    public class ResearcherRepositoryTest
    {
        [Fact]
        public async Task GetAllResearchersAsyncTest()
        {
            var peopleCount = 2;

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<PeopleDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IResearcherRepository, ResearcherRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IResearcherRepository>();

            // act 
            var researchers = await repository.GetAllResearchersAsync();

            // assert
            researchers.Should().HaveCount(peopleCount);
        }

        public static async Task<IEnumerable<ResearcherDto>> GetListResearcherTestByGroup()
        {
            var testData = new List<ResearcherDto>
            {
                new ResearcherDto("TRES", "sivana.hamer@ucr.ac.cr", RequiredString.TryCreate("Sivana").Success(),
                    RequiredString.TryCreate("Hamer").Success(), RequiredString.TryCreate("Campos").Success(),
                    PersonHighestDegree.TryCreate("Bach.").Success(), RequiredString.TryCreate("Universidad de Costa Rica").Success(), null),
            }.AsEnumerable();

            return await Task.FromResult<IEnumerable<ResearcherDto>>(testData);
        }


        [Fact]
        public async Task GetAllResearchersByGroupAsyncTest()
        {
            // arrange
            var groupId = "TRES";

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<PeopleDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IResearcherRepository, ResearcherRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IResearcherRepository>();

            // act 
            var researchers = await repository.GetResearchersByGroupIdAsync(groupId);

            // assert
            researchers.Should().BeEquivalentTo(await GetListResearcherTestByGroup());
        }
    }
}