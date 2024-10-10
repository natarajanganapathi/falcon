namespace Falcon.Messaging;

public class MessagingOptions
{
    public required Action<IBusRegistrationConfigurator> ApplicationBusConfigurator { get; set; }
    public required Action<IBusRegistrationConfigurator> DomainBusConfigurator { get; set; }
    public Action<IBusRegistrationConfigurator>? InfrastructureBusConfigurator { get; set; }
}

