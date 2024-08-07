namespace Falcon.Infrastructure.Abstractions;

public interface IDbContextOptionsProvider
{
    DbContextOptions GetDbContextOption(string connectionString);
}