namespace FalconSample.Events.Command;

public class TestCommand : ICommand
{
    public required string Message { get; set; }
}
