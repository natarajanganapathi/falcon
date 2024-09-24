namespace Falcon.Messaging;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services)
    {
        return services
            .AddScoped<IntegrationEventPublisher>()
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddScoped<ApplicationEventDispatcher>()
            .AddScoped<DomainEventDispatcher>();
    }
}