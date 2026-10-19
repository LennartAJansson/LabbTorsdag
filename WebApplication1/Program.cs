using Scalar.AspNetCore;

using FastEndpoints;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.OpenApi;

using Customers.Features.Customers.Extensions;
using Customers.Infrastructure.Data.Extensions;

using Employees.Features.Employees.Extensions;
using Employees.Infrastructure.Data.Extensions;
using Customers.Infrastructure.Messaging;
using Employees.Infrastructure.Messaging;
using Workloads.Features.Extensions;
using Workloads.Infrastructure.Data.Extensions;
using Workloads.Infrastructure.Messaging;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options => options.AddOperationTransformer((operation, context, cancellationToken) =>
{
  // FastEndpoints binds routes itself, so native ApiExplorer does not describe its path parameters.
  if (!context.Description.ActionDescriptor.EndpointMetadata.OfType<EndpointDefinition>().Any())
    return Task.CompletedTask;

  var route = RoutePatternFactory.Parse(context.Description.RelativePath!);
  foreach (var parameter in route.Parameters)
  {
    operation.Parameters ??= [];
    if (operation.Parameters.Any(p => p.In == ParameterLocation.Path && p.Name == parameter.Name))
      continue;

    operation.Parameters.Add(new OpenApiParameter
    {
      Name = parameter.Name,
      In = ParameterLocation.Path,
      Required = true,
      Schema = new OpenApiSchema { Type = JsonSchemaType.String }
    });
  }

  if (context.Description.HttpMethod == "GET")
    operation.RequestBody = null;

  return Task.CompletedTask;
}));

builder.Services.AddCustomerMessaging()
  .AddEmployeeMessaging()
  .AddWorkloadsMessaging();

builder.Services
  .AddCustomersHandlers()
  .AddEmployeesHandlers()
  .AddWorkloadsHandlers();

builder.Services
  .AddCustomersData(builder.Configuration)
  .AddEmployeesData(builder.Configuration)
  .AddWorkloadsData(builder.Configuration);

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
  .UseEmployeesData()
  .UseWorkloadsData();

app.MapCustomersEndpoints();
app.MapEmployeesEndpoints();

app.Run();
