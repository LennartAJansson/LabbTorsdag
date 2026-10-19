namespace Messaging.Nats;

using System.Runtime.CompilerServices;

using Messaging.Abstract;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using NATS.Client.Core;
using NATS.Client.Serializers.Json;

public class NatsMessaging<T>
  : IMessaging<T>
{
  string subject = "person.info";
  NatsOpts opts;
  NatsConnection connection = null!;
  ILogger<NatsMessaging<T>> logger;

  public NatsMessaging(ILogger<NatsMessaging<T>> logger, string subject)
  {
    this.logger = logger;
    opts = new()
    {
      Url = "nats://localhost:4222",
      Name = "NATS Example",
      SerializerRegistry = NatsJsonSerializerRegistry.Default,
    };
    this.subject = subject;
    connection = new NatsConnection(opts);
  }


  public Task Init()
  {
    return Task.CompletedTask;
  }

  public async Task PublishAsync(Message<T> message, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    logger.LogInformation("Publishing: {MessageType} {PayloadType}", message.Type, message.Payload?.GetType());
    await connection.PublishAsync(subject, message, cancellationToken: cancellationToken);
  }

  public async IAsyncEnumerable<Message<T>> ConsumeAsync([EnumeratorCancellation] CancellationToken cancellationToken)
  {
    await foreach (var msg in connection.SubscribeAsync<Message<T>>(subject, cancellationToken: cancellationToken))
    {
      yield return msg.Data;
    }
  }

  public async Task Done()
  {
    await connection.DisposeAsync();
  }
}
