namespace Falcon.Messaging.ApplicationEvents;

public class ApplicationEventDispatcher
{
    private readonly IMediator _mediator;

    public ApplicationEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Dispatch(IApplicationEvent applicationEvent)
    {
        await _mediator.Publish(applicationEvent);
    }
}
