namespace LightningArc.Persistence.Abstractions;

public interface IDbContextOptionsProvider
{
    DbContextOptions GetDbContextOption(string connectionString);
}