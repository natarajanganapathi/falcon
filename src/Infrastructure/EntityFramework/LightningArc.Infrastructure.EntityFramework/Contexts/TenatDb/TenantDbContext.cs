namespace LightningArc.Infrastructure.EntityFramework.Contexts.TenantDb;

public class TenantDbContext : SqlDbContext
{
    private readonly ITenantDbModelConfiguration _modelConfigProvider;
    public TenantDbContext(ITenantDbModelConfiguration modelConfigProvider, TenantDbContextOptions sqlOptions) : base(sqlOptions.Value)
    {
        _modelConfigProvider = modelConfigProvider;
    }
    protected override ISqlDbModelConfiguration ModelConfigProvider => _modelConfigProvider;
}

