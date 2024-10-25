namespace Falcon.Messaging.Command;

public class CommandSender
{
    private readonly ICommandBus _commandBus;

    public CommandSender(CommandBus commandBus)
    {
        _commandBus = commandBus;
    }

    public Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
    {
        return _commandBus.Publish(command, cancellationToken);
    }
}
