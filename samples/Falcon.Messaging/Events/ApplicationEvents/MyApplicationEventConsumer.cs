
namespace Samples.Falcon.Messaging.Events.ApplicationEvents;

public class MyApplicationEventConsumer : IApplicationEventConsumer<MyApplicationEvent>
{
    private readonly ILogger _logger;
    public MyApplicationEventConsumer(ILogger<MyApplicationEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MyApplicationEvent> context)
    {
        _logger.LogInformation($"Application Event Consumed: {context.Message.Message}");
        return Task.CompletedTask;
    }
}