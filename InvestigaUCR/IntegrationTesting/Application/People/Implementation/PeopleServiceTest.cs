using Application.People;
using Application.People.Implementations;
using Application.ResearchGroups;
using Domain.People.Entities;
using Domain.People.Repositories;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchGroups.Repositories;
using Infrastructure.People.Context.Implementation;
using Infrastructure.People.Repositories;
using Infrastructure.ResearchGroups;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using Infrastructure.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace IntegrationTesting.Application.People.Implementation
{
    public class PeopleServiceTest
    {
        [Fact]
        public async Task PeopleServiceGetPersonByIdAsync()
        {
            var personId = "adrian.lara@ucr.ac.cr";
            var personName = "Adrian";

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
            builder.Services.AddTransient<IPeopleService, PeopleServices>();

            var app = builder.Build();

            var service = app.Services.GetRequiredService<IPeopleService>();

            var person = await service.GetPersonByIdAsync(personId);

            person!.Name.Value.Should().Be(personName);
        }

        [Fact]
        public async Task PeopleServiceGetPeopleAsync()
        {
            var personCount = 16;

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
            builder.Services.AddTransient<IPeopleService, PeopleServices>();

            var app = builder.Build();

            var service = app.Services.GetRequiredService<IPeopleService>();

            var people = await service.GetPeopleAsync();

            people.Should().HaveCount(personCount);
        }

        [Fact]
        public async Task PeopleServiceGetGroupsByPersonID()
        {
            var personId = "adrian.lara@ucr.ac.cr";
            var personCount = 2;

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
            builder.Services.AddTransient<IPeopleService, PeopleServices>();

            var app = builder.Build();

            var service = app.Services.GetRequiredService<IPeopleService>();

            var people = await service.GetGroupsByPersonID(personId);

            people.Should().HaveCount(personCount);
        }

    }
}
