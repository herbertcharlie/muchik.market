using MediatR;
using Microsoft.EntityFrameworkCore;
using muchik.market.infrastructure.bus.settings;
using muchik.market.infrastructure.ioc;
using muchik.market.pay.application.commandHandlers;
using muchik.market.pay.application.commands;
using muchik.market.pay.application.interfaces;
using muchik.market.pay.application.mappings;
using muchik.market.pay.application.services;
using muchik.market.pay.domain.interfaces;
using muchik.market.pay.infrastructure.context;
using muchik.market.pay.infrastructure.repositories;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

//SQL Server
builder.Services.AddDbContext<PayContext>(config =>
{
    //config.UseMySQL("server=localhost; database=db_operation; port=3306; user=root; password=NewHorizons_2023@");
    config.UseMySQL(builder.Configuration.GetValue<string>("connectionStrings:muchikConnection"));

});

//RabbitMQ Settings
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("rabbitMqSettings"));

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<IPayService, PayService>();

//Repositories
builder.Services.AddTransient<IPayRepository, PayRepository>();

//Context
builder.Services.AddTransient<PayContext>();

//Commands & Events
builder.Services.AddTransient<IRequestHandler<CreatePaymentCommand, bool>, CreatePaymentCommandHandler>();

//CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Consul
builder.Services.AddDiscoveryClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
