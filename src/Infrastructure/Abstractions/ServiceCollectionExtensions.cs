namespace Falcon.Infrastructure.Abstractions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrasttructureModule(this IServiceCollection services)
    {
        return services.AddScoped(typeof(IRequestContext<>), typeof(RequestContext<>))
                        // .AddScoped(typeof(BaseService<,>))
                        .AddScoped(typeof(ITenantOptions<>), typeof(TenantOptions<>));
    }

    public static IApplicationBuilder UseInfrastructureMiddelwares(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }

    public static IApplicationBuilder UseInfrastructureModule(this IApplicationBuilder app)
    {
        return app;
    }
}