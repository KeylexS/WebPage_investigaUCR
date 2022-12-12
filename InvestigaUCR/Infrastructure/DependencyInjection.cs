using Domain.ResearchGroups.Repositories;
using Infrastructure.ResearchGroups;
using Infrastructure.ResearchGroups.Repositories;
using Domain.People.Repositories;
using Infrastructure.People.Repositories;
using Infrastrucute.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domain.ResearchProjects.Repositories;
using Infrastructure.ResearchProjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.People.Context.Implementation;
using Infrastructure.Publications.DbContexts;
using Domain.Publications.Entities;
using Infrastructure.Theses.Repositories;
using Infrastructure.Theses.DbContexts;
using Domain.Theses.Entities;
using Infrastructure.Publications.Repositories;
using Domain.ResearchAreas.Repositories;
using Infrastructure.ResearchAreas.DbContexts;
using Domain.Shared.ImageConverter;
using Infrastructure.Shared.ImageConverter;
using Infrastructure.ResearchAreas.Repositories;
using Domain.Shared.Charts.Repositories;
using Infrastructure.Shared.Charts.Repositories;
using Infrastructure.News.Repositories;
using Infrastructure.News;
using Domain.News.Repositories;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Domain.People.Entities;
using Domain.Users.Repositories;
using Domain.Users.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Infrastructure.Users.Repositories;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<GeneralDbContext>(option => option.UseSqlServer(connectionString));

            services.AddScoped<IPeopleRepository, PeopleRepository>();
            
            services.AddScoped<IResearcherRepository, ResearcherRepository>();

            services.AddScoped<ICoordinatorRepository, CoordinatorRepository>();

            //services.AddDbContext<PublicationsDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IPublicationsRepository, PublicationsRepository>();

           // services.AddDbContext<ThesesDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IThesesRepository, ThesesRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString));
            
            services.AddDatabaseDeveloperPageExceptionFilter();
            
            //False for no email confirmation
            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<User>>();

            services.AddScoped<IResearchProjectsRepository, ResearchProjectRepository>();
            //services.AddDbContext<ResearchProjectsDbContext>(options => options.UseSqlServer(connectionString));

            //services.AddDbContext<GroupDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IImageConverter, ImageConverter>();

            //services.AddDbContext<NewsDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<INewsRepository, NewsRepository>();

            //services.AddDbContext<ResearchAreasDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IResearchAreasRepository, ResearchAreaRepository>();

            services.AddScoped<IChartRepository, ChartRepository>();
            services.AddScoped<ICollaborateRepository, CollaborateRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IdentityErrorDescriber, IdentityErrorCustom>();

            return services;
        }
    }
}
