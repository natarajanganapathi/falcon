namespace Falcon.Messaging.ApplicationEvents;

public static class ModuleExtensions
{
    public static IServiceCollection AddApplicationEvents(this IServiceCollection services)
    {
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
        .AddScoped<ApplicationEventDispatcher>();
    }
}