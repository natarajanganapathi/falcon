namespace Falcon.Messaging.Command;

public class CommandSender
{
    private readonly IMediator _mediator;

    public CommandSender(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
    {
        return _mediator.Send(command, cancellationToken);
    }
}
