using Scalar.AspNetCore;

using Customers.Features.Customers.Extensions;
using Customers.Infrastructure.Data.Extensions;

using Employees.Features.Employees.Extensions;
using Employees.Infrastructure.Data.Extensions;
using Customers.Infrastructure.Messaging;
using Employees.Infrastructure.Messaging;
using WebApplication1;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<TestCustomerWorker>()
  .AddHostedService<TestEmployeeWorker>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCustomerMessaging()
  .AddEmployeeMessaging();

builder.Services
  .AddCustomersHandlers()
  .AddEmployeesHandlers();

builder.Services
  .AddCustomersData(builder.Configuration)
  .AddEmployeesData(builder.Configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
  app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app
  .UseCustomersData()
  .UseEmployeesData();

app.MapCustomersEndpoints();
app.MapEmployeesEndpoints();

app.Run();
