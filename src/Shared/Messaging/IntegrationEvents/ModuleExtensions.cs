namespace Falcon.Messaging.IntegrationEvents;

public static class ModuleExtensions
{
    public static IServiceCollection AddIntegrationEventsModule(this IServiceCollection services)
    {
        return services
                .AddScoped<IntegrationEventPublisher>();
    }
}