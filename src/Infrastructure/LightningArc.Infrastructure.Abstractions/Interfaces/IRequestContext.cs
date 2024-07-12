namespace LightningArc.Infrastructure.Abstractions;

public interface IRequestContext<out TId>
{
    public TId UserId { get; }
}