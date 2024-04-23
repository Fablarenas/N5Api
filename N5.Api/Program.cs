using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using N5.Api.Middlewares;
using N5.Application.Commands.Handlers;
using N5.Application.Handlers;
using N5.Application.Interfaces;
using N5.Application.Services;
using N5.Domain.Repositories;
using N5.Infraestructure.DataContext;
using N5.Infraestructure.Repositories;
using N5.Infrastructure.Repositories;
using N5.Infrastructure.Repositories.UnitWorks;
using Nest;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .Enrich.FromLogContext()
    .MinimumLevel.Warning() 
    .MinimumLevel.Override("N5.Api", Serilog.Events.LogEventLevel.Information)
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day));
// Mapper Configuration
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
builder.Services.AddScoped<INotificationPermission, NotificationPermission>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<CreatePermissionCommandHandler>();
builder.Services.AddScoped<GetAllPermissionsQueryHandler>();
builder.Services.AddScoped<ModifyPermissionCommandHandler>();
builder.Services.AddScoped<GetPermissionTypeByIdHandler>();
builder.Services.Configure<KafkaOptions>(builder.Configuration.GetSection("Kafka"));

builder.Services.AddSingleton<KafkaProducer>(serviceProvider => {
    var options = serviceProvider.GetRequiredService<IOptions<KafkaOptions>>().Value;
    return new KafkaProducer(options.BootstrapServers, options.Topic);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<N5DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("N5db")));

// Configurar el cliente de Elasticsearch
var settings = new ConnectionSettings(new Uri(builder.Configuration["ElasticUri"]))
    .DefaultIndex("permissions");

var client = new ElasticClient(settings);

// Registrar el cliente como un servicio para que puedas inyectarlo
builder.Services.AddSingleton<IElasticClient>(client);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<KafkaLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
