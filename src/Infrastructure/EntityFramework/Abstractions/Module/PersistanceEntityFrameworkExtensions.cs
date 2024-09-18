namespace Falcon.Infrastructure.EntityFramework.Abstractions;

public static class PersistanceEntityFrameworkExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = GetServiceScope(app);
        RunDatabaseMigration<HomeDbContext>(scope);
        bool isSingleTenant = scope.ServiceProvider.GetRequiredService<ITenant>() is SingleTenant;
        if (isSingleTenant)
        {
            RunDatabaseMigration<TenantDbContext>(scope);
        }
    }
    private static IServiceScope GetServiceScope(IApplicationBuilder app)
    {
        var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
        return scopeFactory.CreateScope();
    }
    private static void RunDatabaseMigration<TContext>(IServiceScope scope) where TContext : DbContext
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<TContext>();
        dbContext.Database.Migrate();
    }
}
