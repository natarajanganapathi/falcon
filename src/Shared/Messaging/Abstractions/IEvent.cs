namespace Falcon.Messaging.Abstractions;

public interface IEvent
{
    Guid Id { get; }
    DateTime OccurredOn { get; }
}
