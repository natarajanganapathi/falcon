namespace Falcon.Messaging;

public class MessagingOptionsBuilder
{
    private static Action<IBusRegistrationConfigurator> _applicationInMemoryBusRegistration = (cfg) =>
    {
        cfg.UsingInMemory((context, cfg) => { cfg.ConfigureEndpoints(context); });
        cfg.AddDefaultApplicationEventConsumers();
    };

    private static Action<IBusRegistrationConfigurator> _domainInMemoryBusRegistration = (cfg) =>
    {
        cfg.UsingInMemory((context, cfg) => { cfg.ConfigureEndpoints(context); });
        cfg.AddDefaultDomainEventConsumers();
    };

    private static Action<IBusRegistrationConfigurator> _integrationInMemoryBusRegistration = (cfg) =>
    {
        cfg.UsingInMemory((context, cfg) => { cfg.ConfigureEndpoints(context); });
        cfg.AddDefaultIntegrationEventConsumers();
    };

    private Action<IBusRegistrationConfigurator> _applicationBusConfigurator = _applicationInMemoryBusRegistration;
    private Action<IBusRegistrationConfigurator> _domainBusConfigurator = _domainInMemoryBusRegistration;
    private Action<IBusRegistrationConfigurator> _integrationBusConfigurator = _integrationInMemoryBusRegistration;

    public static MessagingOptionsBuilder New() => new();

    public MessagingOptionsBuilder AddApplicationEvent(Action<IBusRegistrationConfigurator> applicationBusConfigurator)
    {
        _applicationBusConfigurator = applicationBusConfigurator;
        return this;
    }

    public MessagingOptionsBuilder AddDomainEvent(Action<IBusRegistrationConfigurator> domainBusConfigurator)
    {
        _domainBusConfigurator = domainBusConfigurator;
        return this;
    }

    public MessagingOptionsBuilder AddIntegrationEvent(Action<IBusRegistrationConfigurator> integrationBusConfigurator)
    {
        _integrationBusConfigurator = integrationBusConfigurator;
        return this;
    }

    public MessagingOptions Build()
    {
        return new MessagingOptions
        {
            ApplicationBusConfigurator = _applicationBusConfigurator,
            DomainBusConfigurator = _domainBusConfigurator,
            InfrastructureBusConfigurator = _integrationBusConfigurator
        };
    }
}
