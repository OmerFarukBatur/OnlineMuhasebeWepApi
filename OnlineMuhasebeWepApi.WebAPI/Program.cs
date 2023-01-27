using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineMuhasebeWepApi.Application.Services.AppServices;
using OnlineMuhasebeWepApi.Domain;
using OnlineMuhasebeWepApi.Domain.AppEntities.Identity;
using OnlineMuhasebeWepApi.Domain.Repositories.UCOARepository;
using OnlineMuhasebeWepApi.Persistance;
using OnlineMuhasebeWepApi.Persistance.Context;
using OnlineMuhasebeWepApi.Persistance.Repositories.UCOARepositories;
using OnlineMuhasebeWepApi.Persistance.Services.AppServices;
using A = OnlineMuhasebeWepApi.Application;
using Pe = OnlineMuhasebeWepApi.Persistance;
using Pr = OnlineMuhasebeWepApi.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.AddScoped<IUCOAReadRepository, UCOAReadRepositry>();
builder.Services.AddScoped<IUCOAWriteRepository, UCOAWriteRepositry>();

builder.Services.AddMediatR(typeof(A.AssemblyReference).Assembly);

builder.Services.AddAutoMapper(typeof(Pe.AssemblyReference).Assembly);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Pr.AssemblyReference).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecuritySheme, Array.Empty<string>() }
        
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
