namespace Employees.Infrastructure.Messaging;

using global::Messaging.Abstract;
using global::Messaging.Channels;
using global::Messaging.Nats;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public static class EmployeesMessagingExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddEmployeeMessaging()
    {
      if (Environment.GetEnvironmentVariable("ISMONOLITH")=="true")
        services.AddChannelMessaging<EmployeeContract>();
      else
        services.AddNatsMessaging<EmployeeContract>("employee.info");
      return services;
    }
  }
}