namespace Employees.Infrastructure.Messaging;

using Microsoft.Extensions.DependencyInjection;

using Workloads.Features.Customers.HandleChanges;
using Workloads.Features.Employees.HandleChanges;

public static class WorkloadsMessagingExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddWorkloadsMessaging()
    {
      services.AddHostedService<CustomerWorker>();
      services.AddHostedService<EmployeeWorker>();

      return services;
    }
  }
}