namespace LightningArc.Application.Abstractions;

public static class ModuleExtensions
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services, IConfiguration configuration, string configPath)
    {
        return services;
    }

    public static IApplicationBuilder UseInfrastructureMiddelwares(this IApplicationBuilder app)
    {
        return app;
    }

    public static IApplicationBuilder UseInfrastructureModule(this IApplicationBuilder app)
    {
        return app;
    }
}