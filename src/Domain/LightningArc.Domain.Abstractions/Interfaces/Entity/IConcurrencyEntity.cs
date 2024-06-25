namespace LightningArc.Domain.Abstractions;

public interface IConcurrencyEntity
{
    int ConcurrencyStamp { get; set; }
}
