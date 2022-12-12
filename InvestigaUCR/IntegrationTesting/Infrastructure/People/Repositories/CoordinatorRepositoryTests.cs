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

    public class CoordinatorRepositoryTests
    {
        [Fact]
        public async Task CoordinatorRepositoryGetAllAsyncTest()
        {
            var peopleCount = 4;

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ICoordinatorRepository, CoordinatorRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<ICoordinatorRepository>();

            // act 
            var people = await repository.GetAllCoordinatorsAsync();

            // assert
            people.Should().HaveCount(peopleCount);
        }

        [Fact]
        public async Task CoordinatorRepositoryGetCoordinatorByPersonId()
        {
            var groupId = "CRCUCRCITICGP";
            var personId = "marcelo.jenkins@ecci.ucr.ac.cr";

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ICoordinatorRepository, CoordinatorRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<ICoordinatorRepository>();

            // act 
            var coordinator = await repository.GetCoordinatorByGroupIdAsync(groupId);

            // assert
            coordinator!.Id.Should().BeEquivalentTo(personId);
        }
    }
}
