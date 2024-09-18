namespace Falcon.Infrastructure.Abstractions;

public interface IRequestContext<out TId>
{
    public TId UserId { get; }
}