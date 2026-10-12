namespace Employees.Features.Employees.Extensions;

using FastEndpoints;

using Microsoft.Extensions.DependencyInjection;

public static class HandlersExtensions
{
  extension(IServiceCollection services)
  {
    /// <summary>
    /// Registers the Employees module's FastEndpoints handlers.
    /// </summary>
    /// <remarks>
    /// <see cref="EndpointServiceCollectionExtensions.AddFastEndpoints"/> is a global, assembly-agnostic
    /// registration (it discovers endpoints across all loaded assemblies) and must only be called once
    /// per application. Since Employees is currently the only module using FastEndpoints, the call is
    /// kept here to encapsulate FastEndpoints-specific wiring within this module.
    /// </remarks>
    public IServiceCollection AddEmployeesHandlers()
    {
      services.AddFastEndpoints();

      return services;
    }
  }
}
