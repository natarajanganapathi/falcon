namespace Falcon.Messaging;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, Func<MessagingOptionsBuilder, MessagingOptionsBuilder> messagingOptions)
    {
        var options = messagingOptions.Invoke(MessagingOptionsBuilder.New())
                                      .Build();
        services
            .AddMassTransitSetup(options)
            .AddMediatRSetup(options)
            .AddMessagingServices();
        return services;
    }

    private static IServiceCollection AddMediatRSetup(this IServiceCollection services, MessagingOptions messagingOptions)
    {
        services.AddMediatR(cfg =>
        {
            messagingOptions.MediatRConfiguration(cfg);
            if (messagingOptions.PreProcessorBehavior is not null)
            {
                foreach (var behavior in messagingOptions.PreProcessorBehavior)
                {
                    cfg.AddBehavior(typeof(IPipelineBehavior<,>), behavior.GetType());
                }
            }
        });
        return services;
    }

    private static IServiceCollection AddMassTransitSetup(this IServiceCollection services, MessagingOptions messagingOptions)
    {
        services.AddMassTransit(cfg =>
        {
            messagingOptions.BusRegistrationConfigurator?.Invoke(cfg);
        });
        return services;
    }
    private static IServiceCollection AddMessagingServices(this IServiceCollection services)
    {
        services.AddScoped<IntegrationEventPublisher>()
                .AddScoped<ApplicationEventDispatcher>()
                .AddScoped<DomainEventDispatcher>();
        return services;
    }
}