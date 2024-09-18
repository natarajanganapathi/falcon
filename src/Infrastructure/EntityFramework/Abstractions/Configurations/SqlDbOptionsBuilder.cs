namespace Falcon.Infrastructure.EntityFramework.Abstractions.Configurations;

public class SqlDbOptionsBuilder
{
    private string _connectionString = string.Empty;

    public static SqlDbOptionsBuilder New() => new();

    public SqlDbOptionsBuilder ConnectionString(string connectionString)
    {
        _connectionString = connectionString;
        return this;
    }

    public SqlDbOptions Build()
    {
        return new SqlDbOptions
        {
            ConnectionString = _connectionString
        };
    }
}
