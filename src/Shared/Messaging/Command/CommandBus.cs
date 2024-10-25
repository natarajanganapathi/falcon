namespace Falcon.Messaging.Command;

public class CommandBus : BusInstance<ICommandBus>, ICommandBus
{
    public CommandBus(IBusControl busControl) : base(busControl) { }
}

