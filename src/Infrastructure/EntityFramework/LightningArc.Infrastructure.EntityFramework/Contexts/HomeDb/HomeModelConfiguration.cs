namespace LightningArc.Infrastructure.EntityFramework.Contexts.HomeDb;

public class HomeModelConfigurations : ModelConfigurations, IHomeDbModelConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        Configure<HomeDbAttribute>(modelBuilder);
    }
}