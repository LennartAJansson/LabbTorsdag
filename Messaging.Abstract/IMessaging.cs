namespace Messaging.Abstract;

public interface IMessaging<T>
{
  Task Init();
  Task PublishAsync(Message<T> message, CancellationToken cancellationToken);
  IAsyncEnumerable<Message<T>> ConsumeAsync(CancellationToken cancellationToken);
  Task Done();
}
