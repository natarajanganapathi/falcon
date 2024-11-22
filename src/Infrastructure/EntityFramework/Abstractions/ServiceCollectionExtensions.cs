namespace Falcon.Infrastructure.EntityFramework;

public static class ServiceCollectionExtensions
{
    private interface IModuleMarker { }
    private sealed class ModuleMarker : IModuleMarker { }
    public static IServiceCollection AddInfrastructureEntityFramework(this IServiceCollection services, IConfiguration configuration, string configPath)
    {
        services.Configure<SqlDbOptions>(configuration.GetSection(configPath));
        return services.AddInfrastructureEntityFramework();
    }

    public static IServiceCollection AddInfrastructureEntityFramework(this IServiceCollection services, IConfigurationSection section)
    {
        services.Configure<SqlDbOptions>(section);
        return services.AddInfrastructureEntityFramework();
    }

    public static IServiceCollection AddInfrastructureEntityFramework(this IServiceCollection services, Action<SqlDbOptions> configure)
    {
        services.Configure(configure);
        return services.AddInfrastructureEntityFramework();
    }

    private static IServiceCollection AddInfrastructureEntityFramework(this IServiceCollection services)
    {
        if (services.Any(s => s.ServiceType == typeof(IModuleMarker)))
        {
            return services;
        }
        services.AddSingleton<IModuleMarker, ModuleMarker>();

        services.AddScoped<ITenant, SingleTenant>();

        services.AddDbContext<HomeDbContext>(ServiceLifetime.Singleton);
        services.AddScoped<HomeDbContextOptions>();
        services.AddScoped(typeof(HomeRepository<,>));
        services.AddScoped<IOptions<DbConfig>, HomeOptions<DbConfig>>();

        services.AddDbContext<TenantDbContext>(ServiceLifetime.Scoped);
        services.AddScoped<TenantDbContextOptions>();
        services.AddScoped<TenantDbMigrationContext>();
        services.AddScoped(typeof(TenantRepository<,>));

        services.AddScoped<IRepositoryProvider, SqlRepositoryProvider>();
        services.AddSingleton<ITenantDbModelConfiguration, TenantModelConfigurations>();
        services.AddSingleton<IHomeDbModelConfiguration, HomeModelConfigurations>();

        services.AddHealthChecks().AddCheck<SqlDbHealthCheck>("SqlDb", tags: ["sqldb", "all"]);

        return services;
    }

    public static IApplicationBuilder UseInfrastructureEntityFrameworkMiddelwares(this IApplicationBuilder app)
    {
        return app;
    }

    public static IApplicationBuilder UseInfrastructureEntityFramework(this IApplicationBuilder app)
    {
        return app;
    }
}