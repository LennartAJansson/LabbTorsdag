namespace Workloads.Features.Extensions;

using Microsoft.Extensions.DependencyInjection;

using global::Workloads.Features.Customers.GetAll;
using global::Workloads.Features.Employees.GetAll;
using global::Workloads.Features.Workloads.GetByCustomer;
using global::Workloads.Features.Workloads.GetByEmployee;
using global::Workloads.Features.Workloads.Start;
using global::Workloads.Features.Workloads.Stop;

public static class HandlersExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddWorkloadsHandlers()
    {
      services.AddScoped<GetAllWorkloadCustomersMapper>();
      services.AddScoped<GetAllWorkloadEmployeesMapper>();
      services.AddScoped<StartWorkloadMapper>();
      services.AddScoped<StopWorkloadMapper>();
      services.AddScoped<GetWorkloadsByCustomerMapper>();
      services.AddScoped<GetWorkloadsByEmployeeMapper>();
      return services;
    }
  }
}
