namespace Falcon.Messaging.Command;

public class CommandPublisher : BusInstance<ICommandBus>, ICommandBus
{
    public CommandPublisher(IBusControl busControl) : base(busControl) { }
}

