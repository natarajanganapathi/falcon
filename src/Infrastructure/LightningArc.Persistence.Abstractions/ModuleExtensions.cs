namespace LightningArc.Persistence.Abstractions;

public static class ModuleExtensions
{
    public static IServiceCollection AddPersistenceAbstractionsModule(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddScoped(typeof(IRequestContext<>), typeof(RequestContext<>))
                        .AddScoped(typeof(BaseService<,>))
                        .AddScoped(typeof(ITenantOptions<>), typeof(TenantOptions<>));
    }

    public static IApplicationBuilder UsePersistenceAbstractionsMiddelwares(this IApplicationBuilder app)
    {
        return app;
    }

    public static IApplicationBuilder UsePersistenceAbstractionsModule(this IApplicationBuilder app)
    {
        return app;
    }
}