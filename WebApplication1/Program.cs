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

// Lägg till FastEndpoints som registrerar alla kodgeneratorer mm för FastEndpoints.
builder.Services.AddFastEndpoints();

// Dessa tre lägger till alla Driving adapters,
// slicar som innehåller endpoints och workers som tar emot requests av olika slag
// Det innebär att AddWorkloadsHandlers() lägger till FastEndpoints endpoints för Workloads, 
// men även de workers som tar emot meddelanden från Customers och Employees.
builder.Services
  .AddCustomersSlices()
  .AddEmployeesSlices()
  .AddWorkloadsSlices();

// Dessa två lägger till Driven adapters (infrastructure - messaging) för Customers och Employees,
// det är dessa som sänder information till Workloads via Messaging.
builder.Services.AddCustomerMessaging()
  .AddEmployeeMessaging();

// Dessa tre lägger till alla Driven adapters för infrastructure - data
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

// Dessa tre använder Driven adapters (infrastructure - data) för Customers, Employees och Workloads
// De kör migrations och säkerställer att databasen är uppdaterad med senaste versionen av modellen.
app
  .UseCustomersData()
  .UseEmployeesData()
  .UseWorkloadsData();

// Denna extension mappar alla MinimalEndpoints som finns i Customers (den enda som använder minimal endpoints)
app.MapCustomersEndpoints();

// Detta anropet mappar ALLA FastEndpoints,
// oavsett om de är i Customers, Employees eller Workloads.
// Detta kan bara göras en gång per applikation,
// eftersom FastEndpoints skannar alla assemblies efter dessa endpoints och mappar dem.
app.UseFastEndpoints(options =>
{
  options.Endpoints.Configurator = endpoint =>
    endpoint.Options(builder => builder.WithTags(endpoint.EndpointType.Assembly.GetName().Name!));
});

//Dessa behövs således inte om man kör som en modulär monolit
//app.MapEmployeesEndpoints();
//app.MapWorkloadsEndpoints();

app.Run();
