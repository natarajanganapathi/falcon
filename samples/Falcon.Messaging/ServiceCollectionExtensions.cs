namespace Samples.Falcon.Messaging;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessagingExtension(this IServiceCollection services)
    {
        // services.AddMessaging();
        services.AddMessaging(cfg =>
        {
            cfg.AddApplicationEvent((applicationBusConfigurator) =>
            {
                applicationBusConfigurator.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
                applicationBusConfigurator.AddConsumers(Assembly.GetExecutingAssembly());
            });

            cfg.AddDomainEvent((domainBusConfigurator) =>
            {
                domainBusConfigurator.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
                domainBusConfigurator.AddConsumers(Assembly.GetExecutingAssembly());
            });

            cfg.AddIntegrationEvent((integrationBusConfigurator) =>
            {
                integrationBusConfigurator.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
                integrationBusConfigurator.AddConsumers(Assembly.GetExecutingAssembly());
            });

            cfg.AddQuery((queryBusConfigurator) =>
            {
                queryBusConfigurator.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
                queryBusConfigurator.AddDefaultQueryConsumers();
                queryBusConfigurator.AddDefaultQueryRequestClient();
            });

            cfg.AddCommand((commandBusConfigurator) =>
            {
                commandBusConfigurator.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
                commandBusConfigurator.AddDefaultCommandConsumers();
            });
        });
        return services;
    }
}
