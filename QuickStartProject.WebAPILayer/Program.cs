using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuickStartProject.WebAPILayer.AutoMapper;
using QuickStartProject.WebAPILayer.Context;
using QuickStartProject.WebAPILayer.Entities;
using QuickStartProject.WebAPILayer.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ApiContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryService<>));
builder.Services.AddAutoMapper(typeof(Mapping));
builder.Services.AddOpenApi();

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ApiContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt =>
    {
        opt
        .WithTitle("QuickStartProject")
        .WithTheme(ScalarTheme.BluePlanet)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();