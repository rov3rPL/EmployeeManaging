using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MediatR;
using EmployeeManaging.Domain.EmployeeAggregate;
using EmployeeManaging.Infrastructure.Repositories;
using EmployeeManaging.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injections
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var connectionString = builder.Configuration.GetConnectionString("EmployeeDbConnectionString");
builder.Services.AddDbContext<EmployeeManaging.Infrastructure.EmployeeContext>(x => x.UseSqlServer(connectionString));

//builder.Services.AddDbContext<EmployeeManaging.Infrastructure.EmployeeContext>(options =>
//    {
//        options.UseSqlServer(configuration["ConnectionString"],
//            sqlServerOptionsAction: sqlOptions =>
//            {
//                sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
//                sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
//            });
//    },
//    ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
//);


builder.Services.AddMediatR(Assembly.GetAssembly(typeof(EmployeeManaging.Domain.Commands.CreateEmployeeCommand))); //Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IKeyGeneratorStrategy, KeyGeneratorStrategy>();
builder.Services.AddSingleton<IEmployeeKeyGenerator, EmployeeKeyGenerator>();
builder.Services.AddSingleton<IEmployeeHiLoRepository, EmployeeHiLoRepository>();


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
