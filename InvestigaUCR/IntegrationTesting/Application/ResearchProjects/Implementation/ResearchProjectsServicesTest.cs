using Domain.ResearchProjects.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ResearchProjects.Repositories;
using Infrastructure.ResearchProjects.Repositories;
using Application.ResearchProjects;
using Application.ResearchProjects.Implementations;
using Infrastructure;

namespace IntegrationTesting.Application.ResearchGroups
{
    public class ResearchProjectsServiceTest
    {
        [Fact]
        public async Task ResearchProjectsServiceGetAllAsyncTest()
        {
            var projectsCount = 5;

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IResearchProjectsRepository, ResearchProjectRepository>();
            builder.Services.AddTransient<IResearchProjectsService, ResearchProjectsService>();

            var app = builder.Build();

            var service = app.Services.GetRequiredService<IResearchProjectsService>();

            var project = await service.GetResearchProjectsAsync();

            project.Should().HaveCount(projectsCount);
        }

        [Fact]
        public async Task ResearchProjectsServiceGetByIdAsyncTest()
        {
            var projectId = "723-B9-343";
            var projectName = "Intervenciones en infancia temprana para reducir la desigualdad en las oportunidades educativas";

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IResearchProjectsRepository, ResearchProjectRepository>();
            builder.Services.AddTransient<IResearchProjectsService, ResearchProjectsService>();

            var app = builder.Build();

            var service = app.Services.GetRequiredService<IResearchProjectsService>();

            var project = await service.GetResearchProjectByIdAsync(projectId);

            project!.Name.Should().Be(projectName);
        }
    }
}
