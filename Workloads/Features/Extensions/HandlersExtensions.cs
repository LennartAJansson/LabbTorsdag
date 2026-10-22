namespace Workloads.Features.Extensions;

using Microsoft.Extensions.DependencyInjection;

using global::Workloads.Features.Customers.GetAll;
using global::Workloads.Features.Employees.GetAll;
using global::Workloads.Features.Workloads.GetByCustomer;
using global::Workloads.Features.Workloads.GetByEmployee;
using global::Workloads.Features.Workloads.Start;
using global::Workloads.Features.Workloads.Stop;
using global::Workloads.Features.Customers.HandleChanges;
using global::Workloads.Features.Employees.HandleChanges;

public static class HandlersExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddWorkloadsHandlers()
    {
      // Dessa är att betrakta som driving adapters, alltså samma som endpoints
      services.AddHostedService<CustomerWorker>();
      services.AddHostedService<EmployeeWorker>();

      // Dessa är dependencies som används för våra slices
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
