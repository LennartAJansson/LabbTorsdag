namespace Employees.Features.Employees.Extensions;

using FastEndpoints;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public static class EndpointExtensions
{
  extension(WebApplication app)
  {
    /// <summary>
    /// Maps the Employees module's FastEndpoints endpoints into the request pipeline.
    /// </summary>
    /// <remarks>
    /// <see cref="EndpointRouteBuilderExtensions.UseFastEndpoints"/> is a global, assembly-agnostic
    /// pipeline call (it maps endpoints discovered across all loaded assemblies) and must only be called
    /// once per application. This call maps both Employees and Workloads endpoints; a separate
    /// UseFastEndpoints call for Workloads must not be added.
    /// </remarks>
    public WebApplication MapEmployeesEndpoints()
    {
      app.UseFastEndpoints(options =>
      {
        options.Endpoints.Configurator = endpoint =>
          endpoint.Options(builder => builder.WithTags(endpoint.EndpointType.Assembly.GetName().Name!));
      });

      return app;
    }
  }
}
