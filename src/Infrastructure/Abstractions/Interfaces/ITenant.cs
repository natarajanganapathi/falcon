namespace Falcon.Infrastructure.Abstractions;

public interface ITenant
{
    public IDictionary<string, string?> Options { get; }
}
