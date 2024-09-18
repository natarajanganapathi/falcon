namespace Falcon.Infrastructure.EntityFramework.Abstractions.Contexts.HomeDb;

public class HomeDbContextOptions : SqlDbContextOptions
{
    public HomeDbContextOptions(IDbContextOptionsProvider dbContextOptionsProvider, IOptions<DbConfig> dbConfig)
        : base(dbContextOptionsProvider, dbConfig.Value.ConnectionString) { }
}