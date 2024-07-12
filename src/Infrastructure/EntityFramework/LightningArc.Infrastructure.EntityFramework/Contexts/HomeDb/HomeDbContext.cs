namespace LightningArc.Infrastructure.EntityFramework.Contexts.HomeDb;

public class HomeDbContext : SqlDbContext
{
    private readonly IHomeDbModelConfiguration _modelConfigProvider;
    public HomeDbContext(IHomeDbModelConfiguration modelConfigProvider, HomeDbContextOptions sqlOptions) : base(sqlOptions.Value)
    {
        _modelConfigProvider = modelConfigProvider;
    }
    protected override ISqlDbModelConfiguration ModelConfigProvider => _modelConfigProvider;
}