using Microsoft.EntityFrameworkCore;
using muchik.market.infrasctructure.crosscutting.Jwt;
using muchik.market.security.api.Middleware;
using muchik.market.security.application.interfaces;
using muchik.market.security.application.mappgins;
using muchik.market.security.application.services;
using muchik.market.security.domain.interfaces;
using muchik.market.security.infrastructure.context;
using muchik.market.security.infrastructure.repositories;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

//Steeltoe Config Server
builder.AddConfigServer();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Automapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

builder.Services.AddDbContext<SecurityContext>(opt =>
{
    opt.UseCosmos(
        builder.Configuration["cosmosDbSettings:endpoint"],
        builder.Configuration["cosmosDbSettings:primaryKey"],
        databaseName: builder.Configuration["cosmosDbSettings:database"]);
});

//Services
builder.Services.AddTransient<ISecurityService, SecurityService>();

//Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();

//Cross-Cutting
builder.Services.AddTransient<IJwtManager, JwtManager>();

//Context
builder.Services.AddTransient<SecurityContext>();

//Consul
builder.Services.AddDiscoveryClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
