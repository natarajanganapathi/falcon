namespace Falcon.Infrastructure.EntityFramework.Abstractions.Contexts;

public interface ISqlDbModelConfiguration
{
    public void Configure(ModelBuilder modelBuilder);
}
