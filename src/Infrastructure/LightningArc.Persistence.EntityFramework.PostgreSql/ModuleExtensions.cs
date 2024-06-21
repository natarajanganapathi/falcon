namespace LightningArc.Persistence.EntityFramework.PostgreSql;

public static class ModuleExtensions
{
    public static IServiceCollection AddEntityFrameworkPostgreSql(IServiceCollection services)
    {
        return services.AddScoped<IDbContextOptionsProvider, DbContextOptionsProvider>();
    }

    public static IApplicationBuilder UseEntityFrameworkPostgreSqlMiddelwares(IApplicationBuilder app)
    {
        return app;
    }

    public static IApplicationBuilder UseEntityFrameworkPostgreSqlModule(IApplicationBuilder app)
    {
        return app;
    }
}