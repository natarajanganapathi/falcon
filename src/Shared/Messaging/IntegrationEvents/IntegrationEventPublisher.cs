namespace Falcon.Messaging.IntegrationEvents;

public class IntegrationEventPublisher
{
    private readonly IBus _bus;

    public IntegrationEventPublisher(IBus bus)
    {
        _bus = bus;
    }

    public async Task Publish(IIntegrationEvent integrationEvent)
    {
        await _bus.Publish(integrationEvent);
    }
}

