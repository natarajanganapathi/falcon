namespace Falcon.Messaging.DomainEvents;

public static class ModuleExtensions
{
    public static IServiceCollection AddDomainEvents(this IServiceCollection services)
    {
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddScoped<DomainEventDispatcher>();
    }
}