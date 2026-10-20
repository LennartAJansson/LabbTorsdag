namespace Messaging.Nats;

using System;
using System.Collections.Generic;
using System.Text;

using Messaging.Abstract;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public static class NatsExtensions
{
  extension(IServiceCollection services
    )
  {
    public IServiceCollection AddNatsMessaging<T>(string subject)
    {
      _=services.AddSingleton<IMessaging<T>>(sp =>
        new NatsMessaging<T>(
          sp.GetRequiredService<ILogger<NatsMessaging<T>>>()
        , subject));
      return services;
    }
  }
}
