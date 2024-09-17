namespace Falcon.Infrastructure.EntityFramework;

public class SingleTenant : ITenant
{
    public SingleTenant(IOptions<SqlDbOptions> options)
    {
        var value = options.Value;
        Options = new Dictionary<string, string?>()
        {
            { $"{nameof(DbConfig)}:{nameof(value.ConnectionString)}", value.ConnectionString }
        };
    }
    public IDictionary<string, string?> Options { get; }
}