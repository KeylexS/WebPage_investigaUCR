/*
US ID: PIIB22II02-186
US name: KS-RP-1.2 Card Display
Technical Task Resolved: PIIB22II02-310 Implement a Research Project Service in Application
 */
using Application.Identity;
using Application.ResearchProjects;
using Application.ResearchProjects.Implementations;
using Application.ResearchGroups;
using Application.ResearchGroups.Implementations;
using Application.People.Implementations;
using Application.People;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Publications;
using Application.Publications.Implementations;
using Application.Shared.Implementations;
using Application.Shared.ImageConverter;
using Application.Theses;
using Application.Theses.Implementations;
using Application.Shared.Charts.Implementations;
using Application.Shared;
using Application.News.Implementations;
using Application.News;
using Application.ResearchAreas;
using Application.ResearchAreas.Implementations;
using Domain.Users.Entities;
using Application.Users;
using Application.Users.Implementation;


//ID US: PIIB22II02-59, task: PIIB22II02-295 Create dependency injection in application

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<User>>();
            services.AddTransient<IResearchProjectsService, ResearchProjectsService>();

            //User story: SD-RG-1.5 && TT: PIIB22II02-286 Create dependency injections
            services.AddTransient<ICollaborateService, CollaborateService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IPeopleService, PeopleServices>();
            services.AddTransient<IPublications, PublicationService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<ITheses, ThesisService>();
            services.AddTransient<IChartService, ChartsService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IResearchAreasService, ResearchAreasService>();
            services.AddTransient<ICoordinatorService, CoordinatorService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IResearcherService, ResearcherServices>();

            services.AddTransient<RegisterService>();

            return services;
        }
    }
}
