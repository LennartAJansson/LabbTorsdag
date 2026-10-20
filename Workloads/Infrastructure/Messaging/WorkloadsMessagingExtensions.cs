namespace Workloads.Infrastructure.Messaging;

using global::Messaging.Abstract;
using global::Messaging.Channels;
using global::Messaging.Nats;

using Microsoft.Extensions.DependencyInjection;

using Workloads.Features.Customers.HandleChanges;
using Workloads.Features.Employees.HandleChanges;

public static class WorkloadsMessagingExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddWorkloadsMessaging()
    {
      if (Environment.GetEnvironmentVariable("ISMONOLITH")=="true")
        services.AddChannelMessaging<CustomerContract>();
      else
        services.AddNatsMessaging<CustomerContract>("customer.info");
      services.AddHostedService<CustomerWorker>();
      services.AddHostedService<EmployeeWorker>();

      return services;
    }
  }
}