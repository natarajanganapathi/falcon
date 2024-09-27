namespace Falcon.Messaging;

public class MessagingOptions
{
    // MediatR configuration
    public required Action<MediatRServiceConfiguration> MediatRConfiguration { get; set; }
    public IEnumerable<IPipelineBehavior<dynamic, dynamic>>? PreProcessorBehavior { get; set; }
    // MassTransit configuration
    public Action<IBusRegistrationConfigurator>? BusRegistrationConfigurator { get; set; }
}

