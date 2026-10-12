namespace Employees.Features.Employees.Extensions;

using FastEndpoints;

using Microsoft.AspNetCore.Builder;

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
    /// once per application. Since Employees is currently the only module using FastEndpoints, the call
    /// is kept here to encapsulate FastEndpoints-specific wiring within this module.
    /// </remarks>
    public WebApplication MapEmployeesEndpoints()
    {
      app.UseFastEndpoints();

      return app;
    }
  }
}
