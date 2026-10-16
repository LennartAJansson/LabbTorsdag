namespace Employees.Infrastructure.Messaging;

using Employees.Features.Employees.Model;

using global::Messaging.Abstract;
using global::Messaging.Channels;

using Microsoft.Extensions.DependencyInjection;

public static class EmployeesMessagingExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddEmployeeMessaging()
    {
      _=services.AddSingleton<IMessaging<EmployeeContract>, ChannelMessaging<EmployeeContract>>();
      return services;
    }
  }
}