namespace Falcon.Infrastructure.EntityFramework.Abstractions.Contexts.TenantDb;

public class TenantDbMigrationContext : DbContext
{
    private readonly ITenantDbModelConfiguration _modelConfigProvider;
    public TenantDbMigrationContext(ITenantDbModelConfiguration modelConfigProvider, TenantDbContextOptions options) : base(options.Value)
    {
        _modelConfigProvider = modelConfigProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _modelConfigProvider.Configure(modelBuilder);
    }
}
