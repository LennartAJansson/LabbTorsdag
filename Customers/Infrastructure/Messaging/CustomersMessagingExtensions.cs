namespace Customers.Infrastructure.Messaging;

using Customers.Features.Customers.Model;

using global::Messaging.Abstract;
using global::Messaging.Channels;
using global::Messaging.Nats;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public static class CustomersMessagingExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddCustomerMessaging()
    {
      _=services.AddSingleton<IMessaging<CustomerContract>>(sp=>
        new NatsMessaging<CustomerContract>(
          sp.GetRequiredService<ILogger<NatsMessaging<CustomerContract>>>()
        , "customer.info"));
      //_=services.AddSingleton<IMessaging<CustomerContract>, ChannelMessaging<CustomerContract>>();
      return services;
    }
  }
}