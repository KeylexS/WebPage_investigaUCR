using Domain.ResearchGroups.Repositories;
using Infrastructure.ResearchGroups;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.ResearchGroups.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Domain.ResearchAreas.Entities;
using Domain.ResearchProjects.Entities;
using Domain.Publications.Entities;
using Domain.ResearchGroups.ValueObjects;
using Domain.Core.Helpers;
using Domain.ResearchGroups.Entities;
using Domain.People.Entities;
using Infrastructure;
using Domain.Theses.Entities;

namespace IntegrationTesting.Infrastructure.ResearchGroups.Repositories
{
    public class GroupRepositoryTests
    {
        [Fact]
        public async Task GroupRepositoryGetAllAsyncTest()
        {
            var groupCount = 8;

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupRepository>();

            var groups = await repository.GetAllAsync();

            groups.Should().HaveCountGreaterThanOrEqualTo(groupCount);
            groups.Should().OnlyHaveUniqueItems();
        }

        [Fact]
        public async Task GroupRepositoryGetByIdAsyncTest()
        {
            var groupId = "CRCUCRCITICESE";
            var groupName = "Ingeniería de software empírica";

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupRepository>();

            var group = await repository.GetByIdAsync(groupId);

            group!.Name.Value.Should().Be(groupName);
        }

        [Fact]
        public async Task GroupRepositoryGetByIdAsyncInstanceTest()
        {
            byte[]? test = null;
            List<ResearchArea> area = new List<ResearchArea>();
            List<ResearchProject> projects = new List<ResearchProject>();
            List<Publication> publications = new List<Publication>();
            List<Thesis> thesis = new List<Thesis>();
            List<Person> person = new List<Person>();
            Person? coordinator = null;
            DateTime? dateTime = null;
            var GroupTest = new
            {
                Id = ResearchGroupId.TryCreate("CRCUCRCITICPRB").Success(),
                ResearchCenterId = 1,
                Name = ResearchGroupName.TryCreate("Prueba").Success(),
                Description = ResearchGroupDescription.TryCreate("Descripcion").Success(),
                Image = test,
                Start_Date = dateTime,
                _researchArea = area,
                ResearchArea = area.AsReadOnly(),
                _researchProjects = projects,
                ResearchProjects = projects.AsReadOnly(),
                _publications = publications,
                Publications = publications.AsReadOnly(),
                _thesis = thesis,
                Thesis = thesis.AsReadOnly(),
                Coordinator = coordinator,
                _person = person,
                Person = person.AsReadOnly(),
            };

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupRepository>();

            var group = await repository.GetByIdAsync("CRCUCRCITICPRB");

            group!.Should().BeEquivalentTo(GroupTest);
        }

        [Fact]
        public async Task GroupSaveAsyncTest()
        {
            var groupId = "CRCUCRCITICPRB";
            var groupName = "Prueba add";

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupRepository>();

            var group = await repository.GetByIdAsync(groupId);
            group!.Name = ResearchGroupName.TryCreate(groupName).Success();
            await repository.SaveAsync(group);

            group!.Name.Value.Should().Be(groupName);

            //Revert changes
            group!.Name = ResearchGroupName.TryCreate("Prueba").Success();
            await repository.SaveAsync(group);
        }

        [Fact]
        public async Task GroupAddNewGroupTest()
        {
            byte[]? test = null;
            DateTime? dateTime = null;
            Group GroupTest = new Group
            (
                ResearchGroupId.TryCreate("CRCUCRCITICPRBB").Success(),
                1,
                ResearchGroupName.TryCreate("Prueba").Success(),
                ResearchGroupDescription.TryCreate("Descripcion").Success(),
                test,
                dateTime
            );

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupRepository>();

            await repository.AddNewGroup(GroupTest);

            var group = await repository.GetByIdAsync(GroupTest.Id.Value);

            group!.Name.Value.Should().Be(GroupTest.Name.Value);

            await repository.DeleteGroup(group);

            //After doing the test you need to remove the group that has been added because
            //if you don't do that, the GetAllAsync test is going to fail.
        }

        [Fact]
        public async Task RemoveGroupTest()
        {
            byte[]? test = null;
            DateTime? dateTime = null;
            Group GroupTest = new Group
            (
                ResearchGroupId.TryCreate("CRCUCRCITICPRBB").Success(),
                1,
                ResearchGroupName.TryCreate("Prueba").Success(),
                ResearchGroupDescription.TryCreate("Descripcion").Success(),
                test,
                dateTime
            );

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupRepository>();

            await repository.AddNewGroup(GroupTest);

            var group = await repository.GetByIdAsync("CRCUCRCITICPRBB");

            await repository.DeleteGroup(group!);

            var grouptest = await repository.GetByIdAsync("CRCUCRCITICPRBB");

           grouptest.Should().BeNull();

            //After doing the test you need to remove the group that has been added because
            //if you don't do that, the GetAllAsync test is going to fail.
        }
    }
}