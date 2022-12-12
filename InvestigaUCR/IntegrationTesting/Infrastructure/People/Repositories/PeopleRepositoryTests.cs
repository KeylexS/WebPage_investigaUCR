using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using Infrastructure.People;
using Domain.People.Repositories;
using Infrastructure.People.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.People.Entities;
using Domain.ResearchGroups.DTOs;
using Infrastructure.People.Context.Implementation;
using Infrastructure;

namespace IntegrationTesting.Infrastructure.People.Repositories
{
    //Task<IEnumerable<GroupDTO>> GetGroupsByPersonID(string? id);

    public class PeopleRepositoryTest
    {
        [Fact]
        public async Task PeopleRepositoryGetByIdAsyncTest()
        {
            var personName = "Sivana";
            //var personId = "sivana.hamer@ucr.ac.cr";

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPeopleRepository>();

            // act 
            var personList = await repository.GetAllAsync();
            var person = personList?.ElementAt(15);

            // assert
            person?.Name.ToString().Should().Be(personName);
        }

        [Fact]
        public async Task PeopleRepositoryGetAllAsyncTest()
        {
            var peopleCount = 16;

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPeopleRepository>();

            // act 
            var people = await repository.GetAllAsync();

            // assert
            people.Should().HaveCount(peopleCount);
        }

        [Fact]
        public async Task PeopleRepositoryGetGroupsByPersonId()
        {
            var personId = "adrian.lara@ucr.ac.cr";

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPeopleRepository>();

            // act 
            var groups = await repository.GetGroupsByPersonID(personId);

            // assert
            groups.Should().HaveCount(2);
        }
    }
}
