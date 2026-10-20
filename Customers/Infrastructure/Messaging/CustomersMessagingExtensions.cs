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
      if (Environment.GetEnvironmentVariable("ISMONOLITH")=="true")
        services.AddChannelMessaging<CustomerContract>();
      else
        services.AddNatsMessaging<CustomerContract>("customer.info");
      return services;
    }
  }
}