using EventManager.Application.Events.Mappings;
using EventManager.Application.Events.Commands.CreateEvent;
using EventManager.Infrastructure.Extensions;
using FluentValidation;
using MediatR;
using EventManager.Application.Interfaces;
using EventManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 👉 AutoMapper
builder.Services.AddAutoMapper(typeof(EventMappingProfile).Assembly);

// 👉 MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateEventCommand>());

// 👉 FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateEventValidator>();

// 👉 DbContext + Repositórios + UoW
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? "Server=(localdb)\\MSSQLLocalDB;Database=EventManagerDb;Trusted_Connection=True;";
builder.Services.AddInfrastructure(connectionString);

// 👇 Se não estiver dentro do AddInfrastructure
builder.Services.AddScoped<IEventRepository, EventRepository>();

// 👉 Swagger + Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
