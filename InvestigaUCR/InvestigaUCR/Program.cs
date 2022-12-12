using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.StaticFiles;
using Blazored.Modal;
using Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
// PIIB22II02-899 MC - PL - 5.3 Confirmation email for register Task: PIIB22II02-1307 Add timeout of 5 min when register Dev (Sam Cheang)
builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
       o.TokenLifespan = TimeSpan.FromMinutes(5));
var app = builder.Build();

if (builder.Environment.IsStaging())
{
    builder.WebHost.UseStaticWebAssets();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings["{EXTENSION}"] = "{CONTENT TYPE}";

app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();

//Allow dots in the route of persons (email).
app.MapFallbackToPage("/_Host");
app.MapFallbackToPage("/personas/{param?}", "/_Host");

app.Run();

