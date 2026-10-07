namespace Customers.Features.Customers.Extensions;

using System.Reflection;

using global::Customers.Features.Customers.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

public static class EndpointExtensions
{
  extension(IEndpointRouteBuilder app)
  {
    public IEndpointRouteBuilder MapCustomersEndpoints()
    {
      RouteGroupBuilder group = app.MapGroup("/customers");

      var endpointTypes = typeof(IEndpoint).Assembly
        .GetTypes()
        .Where(type => type is { IsClass: true, IsAbstract: false } && typeof(IEndpoint).IsAssignableFrom(type));

      foreach (var endpointType in endpointTypes)
      {
        var endpoint = (IEndpoint)Activator.CreateInstance(endpointType)!;
        endpoint.SetupEndpoint(group);
      }

      return app;
    }
  }
}
