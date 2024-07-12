namespace LightningArc.Infrastructure.Abstractions;

public interface IDbContextOptionsProvider
{
    DbContextOptions GetDbContextOption(string connectionString);
}