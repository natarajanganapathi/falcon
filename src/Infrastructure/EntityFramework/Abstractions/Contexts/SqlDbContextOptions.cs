namespace Falcon.Infrastructure.EntityFramework.Abstractions.Contexts;

public abstract class SqlDbContextOptions
{
    public DbContextOptions Value { get; }
    protected SqlDbContextOptions(IDbContextOptionsProvider dbContextOptionsProvider, string connectionString)
    {
        Value = dbContextOptionsProvider.GetDbContextOption(connectionString);
    }
}
