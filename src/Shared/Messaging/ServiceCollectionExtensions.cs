namespace Falcon.Messaging;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, Action<MessagingOptionsBuilder>? messagingOptionsBuilder = default)
    {
        var optionBuilder = MessagingOptionsBuilder.New();
        messagingOptionsBuilder?.Invoke(optionBuilder);
        var options = optionBuilder.Build();

        services
            .AddApplicationEventSetup(options)
            .AddDomainEventSetup(options)
            .AddIntegrationEventSetup(options);
        return services;
    }

    private static IServiceCollection AddApplicationEventSetup(this IServiceCollection services, MessagingOptions messagingOptions)
    {
        services.AddMassTransit<IApplicationEventBus>(messagingOptions.ApplicationBusConfigurator);

        services.AddSingleton(provider =>
        {
            var applicationEventBus = provider.GetRequiredService<IApplicationEventBus>();
            return new ApplicationEventPublisher(applicationEventBus);
        });
        return services;
    }

    private static IServiceCollection AddDomainEventSetup(this IServiceCollection services, MessagingOptions messagingOptions)
    {
        services.AddMassTransit<IDomainEventBus>(messagingOptions.DomainBusConfigurator);
        services.AddSingleton(provider =>
        {
            var domainEventBus = provider.GetRequiredService<IDomainEventBus>();
            return new DomainEventPublisher(domainEventBus);
        });
        return services;
    }

    private static IServiceCollection AddIntegrationEventSetup(this IServiceCollection services, MessagingOptions messagingOptions)
    {
        if (messagingOptions.InfrastructureBusConfigurator is not null)
        {
            services.AddMassTransit<IIntegrationEventBus>(messagingOptions.InfrastructureBusConfigurator);
            services.AddSingleton(provider =>
            {
                var integrationEventBus = provider.GetRequiredService<IIntegrationEventBus>();
                return new IntegrationEventPublisher(integrationEventBus);
            });
        }
        return services;
    }

    public static void AddDefaultApplicationEventConsumers(this IBusRegistrationConfigurator cfg)
    {
        var filteredTypes = NonAbstractClasses
                            .Where(type =>
                                type.GetInterfaces().Any(i =>
                                    i.IsGenericType &&
                                    i.GetGenericTypeDefinition() == typeof(IApplicationEventConsumer<>)
                                )
                            )
                            .ToList();
        cfg.AddConsumers(filteredTypes?.ToArray());
    }
    public static void AddDefaultDomainEventConsumers(this IBusRegistrationConfigurator cfg)
    {
        var filteredTypes = NonAbstractClasses
                            .Where(type =>
                                type.GetInterfaces().Any(i =>
                                    i.IsGenericType &&
                                    i.GetGenericTypeDefinition() == typeof(IDomainEventConsumer<>)
                                )
                            )
                            .ToList();
        cfg.AddConsumers(filteredTypes?.ToArray());
    }

    public static void AddDefaultIntegrationEventConsumers(this IBusRegistrationConfigurator cfg)
    {
        var filteredTypes = NonAbstractClasses
                            .Where(type =>
                                type.GetInterfaces().Any(i =>
                                    i.IsGenericType &&
                                    i.GetGenericTypeDefinition() == typeof(IIntegrationEventConsumer<>)
                                )
                            )
                            .ToList();
        cfg.AddConsumers(filteredTypes?.ToArray());
    }

    private static IEnumerable<Type> _allTypes = default!;
    private static IEnumerable<Type> AllTypes
    {
        get
        {
            if (_allTypes is null)
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                var assemblies = entryAssembly?.GetReferencedAssemblies()
                        .Select(Assembly.Load)
                        .Append(entryAssembly)
                        .SelectMany(assembly => assembly.GetTypes());
                _allTypes = assemblies ?? Enumerable.Empty<Type>();
            }
            return _allTypes;
        }
    }

    private static IEnumerable<Type> _nonAbstractClasses = default!;
    private static IEnumerable<Type> NonAbstractClasses
    {
        get
        {
            if (_nonAbstractClasses is null)
            {
                _nonAbstractClasses = AllTypes.Where(type =>
                       !type.IsAbstract &&
                       type.IsClass
                       );
            }
            return _nonAbstractClasses;
        }
    }
}