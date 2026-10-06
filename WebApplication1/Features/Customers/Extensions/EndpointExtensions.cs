namespace WebApplication1.Features.Customers.Extensions;

using System.Reflection;

using WebApplication1.Features.Customers.Core;

public static class EndpointExtensions
{
  extension(IEndpointRouteBuilder app)
  {
    public IEndpointRouteBuilder MapEndpoints()
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
