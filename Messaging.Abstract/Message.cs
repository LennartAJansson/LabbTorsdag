namespace Messaging.Abstract;

public record Message<T>(MessageType Type, T Payload);
