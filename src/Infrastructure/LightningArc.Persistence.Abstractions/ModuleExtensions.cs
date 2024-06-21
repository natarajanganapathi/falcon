namespace LightningArc.Persistence.Abstractions;

public static class ModuleExtensions
{
    public static IServiceCollection AddPersistenceAbstractionsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRequestContext<>), typeof(RequestContext<>));
        services.AddScoped(typeof(BaseService<,>));
        services.AddScoped(typeof(ITenantOptions<>), typeof(TenantOptions<>));
        
        return services;
    }

    public static void UsePersistenceAbstractionsMiddelwares(this IApplicationBuilder app)
    {
        // Method intentionally left empty. 
    }

    public static void UsePersistenceAbstractionsModule(this IApplicationBuilder app)
    {
        // Method intentionally left empty.
    }
}