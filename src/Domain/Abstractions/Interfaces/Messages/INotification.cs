namespace Falcon.Domain.Abstractions.Interfaces.Messages;

public interface INotification
{
    Task PublishAsync<T>(T message);
    void Subscribe<T>(Func<T, Task> handler);
}