using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Builder;
using Domain.People.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FluentAssertions;
using Domain.ResearchProjects.Repositories;
using Infrastructure.ResearchProjects.Repositories;
using Infrastructure.People.Context.Implementation;
using Infrastructure.People.Repositories;
using Domain.ResearchGroups.Repositories;
using Infrastructure.ResearchGroups.Repositories;
using Infrastructure.ResearchGroups;
using Domain.Core.Repositories;
using Domain.ResearchProjects.Entities;
using Domain.ResearchProjects.ValueObjects;
using Domain.Core.Helpers;
using Infrastructure;

namespace IntegrationTesting.Infrastructure.ResearchProjects.Repositories;
public class ResearchProjectRepositoryTests
{
    [Fact]
    public async Task ResearchProjectServiceGetByIdAsyncTest()
    {
        var projectId = "723-B9-343";
        var projectName = "Intervenciones en infancia temprana para reducir la desigualdad en las oportunidades educativas";

        var builder = WebApplication.CreateBuilder();
        builder.Services.AddDbContext<GeneralDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IResearchProjectsRepository, ResearchProjectRepository>();
        var app = builder.Build();
        var repository = app.Services.GetRequiredService<IResearchProjectsRepository>();
        var project = await repository.GetByIdAsync(projectId);


        project!.Name.Should().Be(projectName);
    }

    [Fact]
    public async Task ResearchProjectRepositoryGetAllAsyncTest()
    {
        var projectCount = 7;

        var builder = WebApplication.CreateBuilder();
        builder.Services.AddDbContext<GeneralDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IResearchProjectsRepository, ResearchProjectRepository>();

        var app = builder.Build();
        var repository = app.Services.GetRequiredService<IResearchProjectsRepository>();
        var projects = await repository.GetAllAsync();

        projects.Should().HaveCount(projectCount);
    }

    [Fact]
    public async Task DeleteResearchProjectTest()
    {
        //arrange
        DateTime date1 = new DateTime(2015, 3, 10, 2, 15, 10);
        DateTime date2 = new DateTime(2015, 7, 15, 6, 30, 20);
        ResearchProject researchProjectTest = new ResearchProject(ResearchProjectId.TryCreate("123-A1-123").Success(), "Name1", date1, date2, "description1", null);

        var builder = WebApplication.CreateBuilder();
        builder.Services.AddDbContext<GeneralDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IResearchProjectsRepository, ResearchProjectRepository>();
        var app = builder.Build();
        var repository = app.Services.GetRequiredService<IResearchProjectsRepository>();

        await repository.SaveResearchProject(researchProjectTest);

        //act
        await repository.DeleteResearchProject(researchProjectTest);

        //assert
        var project = await repository.GetByIdAsync(researchProjectTest.Id.ToString());
        project.Should().Be(null);
    }

    [Fact]
    public async Task SaveResearchProjectTest()
    {
        DateTime date1 = new DateTime(2015, 3, 10, 2, 15, 10);
        DateTime date2 = new DateTime(2015, 7, 15, 6, 30, 20);
        ResearchProject researchProjectTest = new ResearchProject(ResearchProjectId.TryCreate("123-A1-123").Success(), "Name1", date1, date2, "description1", null);

        var builder = WebApplication.CreateBuilder();

        builder.Services.AddDbContext<GeneralDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IResearchProjectsRepository, ResearchProjectRepository>();

        var app = builder.Build();

        var repository = app.Services.GetRequiredService<IResearchProjectsRepository>();

        await repository.SaveResearchProject(researchProjectTest);

        var project = await repository.GetByIdAsync(researchProjectTest.Id.ToString());

        project!.Name.Should().Be(researchProjectTest.Name);

        await repository.DeleteResearchProject(researchProjectTest);
    }
}
