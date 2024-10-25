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

    private static Action<IBusRegistrationConfigurator> _queryInMemoryBusRegistration = (cfg) =>
    {
        cfg.UsingInMemory((context, cfg) => { cfg.ConfigureEndpoints(context); });
        cfg.AddDefaultQueryConsumers();
        cfg.AddDefaultQueryRequestClient();
        cfg.SetDefaultRequestTimeout(TimeSpan.FromSeconds(10));
    };

    private static Action<IBusRegistrationConfigurator> _commandInMemoryBusRegistration = (cfg) =>
    {
        cfg.UsingInMemory((context, cfg) => { cfg.ConfigureEndpoints(context); });
        cfg.AddDefaultCommandConsumers();
    };

    private Action<IBusRegistrationConfigurator> _applicationBusConfigurator = _applicationInMemoryBusRegistration;
    private Action<IBusRegistrationConfigurator> _domainBusConfigurator = _domainInMemoryBusRegistration;
    private Action<IBusRegistrationConfigurator> _integrationBusConfigurator = _integrationInMemoryBusRegistration;
    private Action<IBusRegistrationConfigurator> _queryBusConfigurator = _queryInMemoryBusRegistration;
    private Action<IBusRegistrationConfigurator> _commandBusConfigurator = _commandInMemoryBusRegistration;

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

    public MessagingOptionsBuilder AddQuery(Action<IBusRegistrationConfigurator> queryBusConfigurator)
    {
        _queryBusConfigurator = queryBusConfigurator;
        return this;
    }

    public MessagingOptionsBuilder AddCommand(Action<IBusRegistrationConfigurator> commandBusConfigurator)
    {
        _commandBusConfigurator = commandBusConfigurator;
        return this;
    }

    public MessagingOptions Build()
    {
        return new MessagingOptions
        {
            ApplicationBusConfigurator = _applicationBusConfigurator,
            DomainBusConfigurator = _domainBusConfigurator,
            InfrastructureBusConfigurator = _integrationBusConfigurator,
            QueryBusConfigurator = _queryBusConfigurator,
            CommandBusConfigurator = _commandBusConfigurator
        };
    }
}
