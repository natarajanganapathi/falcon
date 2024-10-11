namespace Falcon.Messaging;

public static class ServiceCollectionExtensions
{
    private static readonly IEnumerable<Type> _allTypes = LoadAllTypes();
    private static IEnumerable<Type> AllTypes => _allTypes;

    private static readonly IEnumerable<Type> _nonAbstractClasses = LoadNonAbstractClasses();
    private static IEnumerable<Type> NonAbstractClasses => _nonAbstractClasses;

    public static IServiceCollection AddMessaging(this IServiceCollection services, Action<MessagingOptionsBuilder>? messagingOptionsBuilder = default)
    {
        var optionBuilder = MessagingOptionsBuilder.New();
        messagingOptionsBuilder?.Invoke(optionBuilder);
        var options = optionBuilder.Build();

        services
            .AddQuerySetup(options)
            .AddApplicationEventSetup(options)
            .AddDomainEventSetup(options)
            .AddIntegrationEventSetup(options);
        return services;
    }

    #region Application Event

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

    #endregion

    #region Domain Event

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
    #endregion

    #region Integration Event

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
    #endregion

    #region Query
    private static readonly IEnumerable<(Type Consumer, Type QueryType)> _queryConsumerTypes = GetQueryConsumerTypes();
    private static IEnumerable<(Type Consumer, Type QueryType)> QueryConsumerTypes => _queryConsumerTypes;

    private static IServiceCollection AddQuerySetup(this IServiceCollection services, MessagingOptions messagingOptions)
    {
        return services.AddMassTransit(messagingOptions.QueryBusConfigurator);
    }

    private static IEnumerable<(Type Consumer, Type QueryType)> GetQueryConsumerTypes()
    {
        var queryConsumerTypes = NonAbstractClasses
                    .Select(type =>
                    {
                        var genericType = type.GetInterfaces()
                            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryConsumer<>))
                            .Select(i => i.GenericTypeArguments[0])
                            .FirstOrDefault();
                        return (Consumer: type, QueryType: genericType);
                    }).Where(x => x.QueryType is not null);
        return queryConsumerTypes!;
    }

    public static void AddDefaultQueryConsumers(this IBusRegistrationConfigurator cfg)
    {
        var consumers = QueryConsumerTypes?
            .GroupBy(item => item.QueryType)
            .Select(group => group.FirstOrDefault().Consumer)
            .ToArray();
        cfg.AddConsumers(consumers);
    }

    public static void AddDefaultQueryRequestClient(this IBusRegistrationConfigurator cfg)
    {
        var filteredTypes = NonAbstractClasses.Where(type => typeof(IQuery).IsAssignableFrom(type));
        foreach (var queryType in filteredTypes)
        {
            cfg.AddRequestClient(queryType);
        }
    }
    #endregion

    #region Command

    #endregion

    #region Common

    public static void LogQueryConsumers(this IServiceCollection services)
    {
        QueryConsumerTypes
        .GroupBy(item => item.QueryType)
        .ToList()
        .ForEach(group =>
             Console.WriteLine($"Query: {group.Key.Name}, Count: {group.Count()},  Consumers: {string.Join(", ", group.Select(x => x.Consumer.Name))}"));
    }

    private static IEnumerable<Type> LoadAllTypes()
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        var assemblies = entryAssembly?.GetReferencedAssemblies()
                        .Select(Assembly.Load)
                        .Append(entryAssembly)
                        .SelectMany(assembly => assembly.GetTypes());

        return assemblies ?? Enumerable.Empty<Type>();
    }

    private static IEnumerable<Type> LoadNonAbstractClasses()
    {
        return AllTypes.Where(type => !type.IsAbstract && type.IsClass);
    }
    #endregion
}