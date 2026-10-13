namespace Employees.Features.Employees.Extensions;

using global::Employees.Features.Employees.CreateEmployee;
using global::Employees.Features.Employees.DeleteEmployee;
using global::Employees.Features.Employees.GetAllEmployees;
using global::Employees.Features.Employees.GetEmployee;
using global::Employees.Features.Employees.UpdateEmployee;

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

      // FastEndpoints does not register Mapper<TRequest,TResponse,TEntity> types in the DI container
      // by default, even when declared as the TMapper generic argument on an Endpoint. Since our
      // ICommandHandler implementations inject their mapper via the constructor, each mapper must be
      // registered explicitly here.
      services.AddScoped<CreateEmployeeMapper>();
      services.AddScoped<UpdateEmployeeMapper>();
      services.AddScoped<DeleteEmployeeMapper>();
      services.AddScoped<GetEmployeeMapper>();
      services.AddScoped<GetAllEmployeesMapper>();

      return services;
    }
  }
}
