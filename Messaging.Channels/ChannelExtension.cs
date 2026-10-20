namespace Messaging.Channels;

using Messaging.Abstract;

using Microsoft.Extensions.DependencyInjection;

public static class ChannelExtension
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddChannelMessaging<T>()
    {
      _=services.AddSingleton<IMessaging<T>, ChannelMessaging<T>>();
      return services;
    }
  }
}
