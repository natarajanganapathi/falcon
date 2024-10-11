namespace FalconSample.Events.Command;

public class TestCommandConsumer : ICommandConsumer<TestCommand>
{
    private readonly ILogger _logger;
    public TestCommandConsumer(ILogger<TestCommandConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<TestCommand> context)
    {
        _logger.LogInformation($"Command Consumed: {context.Message.Message}");
        return context.RespondAsync(new TestQueryResponse { Value = 2 });
    }
}