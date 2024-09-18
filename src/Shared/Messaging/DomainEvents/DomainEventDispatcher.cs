namespace Falcon.Messaging.DomainEvents;

public class DomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Dispatch(IDomainEvent domainEvent)
    {
        await _mediator.Publish(domainEvent);
    }
}