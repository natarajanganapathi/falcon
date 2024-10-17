namespace Samples.Falcon.Messaging.Events.Command;

public class TestCommand : ICommand
{
    public required string Message { get; set; }
}
