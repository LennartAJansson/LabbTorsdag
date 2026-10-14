namespace Messaging.Channels;

using System.Runtime.CompilerServices;
using System.Threading.Channels;

using Messaging.Abstract;

using Microsoft.Extensions.Logging;

public class ChannelMessaging<T>(ILogger<ChannelMessaging<T>> logger) : IMessaging<T>
{
  Channel<Message<T>>? channel = null;

  public Task Init()
  {
    channel= Channel.CreateUnbounded<Message<T>>();
    return Task.CompletedTask;
  }

  public async IAsyncEnumerable<Message<T>> ConsumeAsync([EnumeratorCancellation] CancellationToken cancellationToken)
  {
    await foreach (Message<T> msg in channel.Reader.ReadAllAsync(cancellationToken))
    {
      yield return msg;
    }
  }

  public async Task PublishAsync(Message<T> message, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    logger.LogInformation("Publishing: {MessageType} {PayloadType}", message.Type, message.Payload?.GetType());
    await channel.Writer.WriteAsync(message, cancellationToken);
  }

  public Task Done()
  {
    channel.Writer.Complete();
    return Task.CompletedTask;
  }
}
