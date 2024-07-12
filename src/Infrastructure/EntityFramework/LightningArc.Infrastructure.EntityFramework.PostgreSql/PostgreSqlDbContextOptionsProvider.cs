namespace LightningArc.Infrastructure.EntityFramework.PostgreSql;

public class PostgreSqlDbContextOptionsProvider : IDbContextOptionsProvider
{
    public DbContextOptions GetDbContextOption(string connectionString)
    {
        return new DbContextOptionsBuilder()
                    .UseNpgsql(connectionString)
                    .Options;
    }
}