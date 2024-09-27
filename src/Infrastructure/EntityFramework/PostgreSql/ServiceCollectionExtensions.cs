namespace Falcon.Infrastructure.EntityFramework.PostgreSql;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureEntityFrameworkPostgreSql(IServiceCollection services)
    {
        return services.AddScoped<IDbContextOptionsProvider, PostgreSqlDbContextOptionsProvider>();
    }

    public static IApplicationBuilder UseInfrastructureEntityFrameworkPostgreSqlMiddelwares(IApplicationBuilder app)
    {
        return app;
    }

    public static IApplicationBuilder UseInfrastructureEntityFrameworkPostgreSqlModule(IApplicationBuilder app)
    {
        return app;
    }
}