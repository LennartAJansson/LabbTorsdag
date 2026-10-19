namespace Employees.Infrastructure.Messaging;

using Employees.Features.Employees.Model;

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
      _=services.AddSingleton<IMessaging<EmployeeContract>>(sp=>
        new NatsMessaging<EmployeeContract>(
          sp.GetRequiredService<ILogger<NatsMessaging<EmployeeContract>>>()
        , "employee.info"));
      //_=services.AddSingleton<IMessaging<EmployeeContract>, ChannelMessaging<EmployeeContract>>();
      return services;
    }
  }
}