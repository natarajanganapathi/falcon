namespace LightningArc.Infrastructure.EntityFramework.Contexts;

public interface ISqlDbModelConfiguration
{
    public void Configure(ModelBuilder modelBuilder);
}
