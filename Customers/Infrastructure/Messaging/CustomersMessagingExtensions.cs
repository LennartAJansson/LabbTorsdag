namespace Customers.Infrastructure.Messaging;

using Customers.Features.Customers.Model;

using global::Messaging.Abstract;
using global::Messaging.Channels;

using Microsoft.Extensions.DependencyInjection;

public static class CustomersMessagingExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddCustomerMessaging()
    {
      _=services.AddSingleton<IMessaging<Customer>, ChannelMessaging<Customer>>();
      return services;
    }
  }
}