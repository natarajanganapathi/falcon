namespace Falcon.Infrastructure.EntityFramework.Abstractions.Contexts.TenantDb;

public class TenantModelConfigurations : ModelConfigurations, ITenantDbModelConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        Configure<TenantDbAttribute>(modelBuilder);
    }
}