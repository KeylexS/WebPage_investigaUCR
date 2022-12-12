using Application.ResearchGroups;
using Application.ResearchGroups.Implementations;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.People.Entities;
using Domain.People.ValueObjects;
using Domain.Publications.Entities;
using Domain.ResearchAreas.Entities;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.Repositories;
using Domain.ResearchGroups.ValueObjects;
using Domain.ResearchProjects.Entities;
using Domain.Theses.Entities;
using FluentAssertions;
using Infrastructure;
using Infrastructure.ResearchGroups;
using Infrastructure.ResearchGroups.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting.Application.ResearchGroups
{
    public class GroupServiceTest
    {
        [Fact]
        public async Task GroupServiceGetAllAsyncTest()
        {
            var groupsCount = 8;

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddTransient<IGroupService, GroupService>();

            var app = builder.Build();

            var service = app.Services.GetRequiredService<IGroupService>();

            var groups = await service.GetGroupAsync();

            groups.Should().HaveCountGreaterThanOrEqualTo(groupsCount);
            groups.Should().OnlyHaveUniqueItems();
        }

        [Fact]
        public async Task GroupServiceGetByIdAsyncTest()
        {
            var groupId = "CRCUCRCITICESE";
            var groupName = "Ingeniería de software empírica";

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddTransient<IGroupService, GroupService>();

            var app = builder.Build();

            var service = app.Services.GetRequiredService<IGroupService>();

            var group = await service.GetGroupByIdAsync(groupId);

            group!.Name.Value.Should().Be(groupName);
        }

        [Fact]
        public async Task GroupServiceGetByIdAsyncInstanceTest()
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
            builder.Services.AddTransient<IGroupService, GroupService>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupService>();

            var group = await repository.GetGroupByIdAsync(GroupTest.Id.Value);

            group!.Should().BeEquivalentTo(GroupTest);
        }

        [Fact]
        public async Task SaveGroupImageTest()
        {
            byte[]? aux = { 1, 1, 1 };

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddTransient<IGroupService, GroupService>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupService>();

            var group = await repository.GetGroupByIdAsync("CRCUCRCITICPRB");
            await repository.SaveGroupImage(group!, aux);

            group!.Image.Should().BeEquivalentTo(aux);

            await repository.SaveGroupImage(group!, null);
        }

        [Fact]
        public async Task SaveGroupNameTest()
        {
            ResearchGroupName _name = ResearchGroupName.TryCreate("Prueba.").Success();

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddTransient<IGroupService, GroupService>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupService>();

            var group = await repository.GetGroupByIdAsync("CRCUCRCITICPRB");
            await repository.SaveGroupName(group!, _name);

            group!.Name.Value.Should().BeEquivalentTo(_name.Value);

            await repository.SaveGroupName(group!, ResearchGroupName.TryCreate("Prueba").Success());
        }

        [Fact]
        public async Task SaveGroupDescriptionTest()
        {
            ResearchGroupDescription _description = ResearchGroupDescription.TryCreate("Descripcion.").Success();

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddTransient<IGroupService, GroupService>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupService>();

            var group = await repository.GetGroupByIdAsync("CRCUCRCITICPRB");
            await repository.SaveGroupDescription(group!, _description);

            group!.Description.Value.Should().BeEquivalentTo(_description.Value);

            await repository.SaveGroupDescription(group!, ResearchGroupDescription.TryCreate("Descripcion").Success());
        }

        [Fact]
        public async Task AddGroupTest()
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
            builder.Services.AddTransient<IGroupService, GroupService>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupService>();

            await repository.AddGroup(GroupTest);
            var group = await repository.GetGroupByIdAsync("CRCUCRCITICPRBB");

            group!.Name.Value.Should().BeEquivalentTo(GroupTest.Name.Value);

            await repository.DeleteResearchGroup(group!);
        }

        [Fact]
        public async Task AddAreaToGroupTest()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddTransient<IGroupService, GroupService>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupService>();

            var group = await repository.GetGroupByIdAsync("CRCUCRCITICESE");

            List<ResearchArea> areas = (List<ResearchArea>)await repository.GetAllAreasAsync();
            await repository.AddAreaToGroup(group!, areas);

            var groupT = await repository.GetGroupByIdAsync("CRCUCRCITICESE");

            groupT!.ResearchArea.Should().HaveCount(7);   
            
            foreach(var area in areas)
            {
                await repository.RemoveAreaofGroup(groupT, area);
            }               
        }

        [Fact]
        public async Task DeleteAreaToGroupTest()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddTransient<IGroupService, GroupService>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupService>();

            var group = await repository.GetGroupByIdAsync("CRCUCRCITICESE");

            List<ResearchArea> areas = (List<ResearchArea>)await repository.GetAllAreasAsync();
            await repository.AddAreaToGroup(group!, areas);

            var groupT = await repository.GetGroupByIdAsync("CRCUCRCITICESE");

            await repository.RemoveAreaofGroup(group!, areas.Find(p => p.Id == 1)!);

            groupT!.ResearchArea.Should().HaveCount(6);

            foreach (var area in areas)
            {
                await repository.RemoveAreaofGroup(groupT, area);
            }
        }

        [Fact]
        public async Task ChangeCoordinatorTest()
        {
            var person = new Person("Email1", RequiredString.TryCreate("Marcelo").Success(), RequiredString.TryCreate("Jenkins").Success(),
                            RequiredString.TryCreate("Coronas").Success(), PersonHighestDegree.TryCreate("Dr.").Success(),
                            RequiredString.TryCreate("Universidad de Costa Rica").Success(), null);

            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<GeneralDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddTransient<IGroupService, GroupService>();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IGroupService>();

            var group = await repository.GetGroupByIdAsync("CRCUCRCITICPRB");

            await repository.ChangeCoordinator(group!, person);

            group!.Coordinator.Should().NotBeNull();

            await repository.ChangeCoordinator(group!, null);
        }
    }
}
