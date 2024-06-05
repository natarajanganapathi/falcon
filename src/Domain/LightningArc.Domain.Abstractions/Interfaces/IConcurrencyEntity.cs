namespace LightningArc.Domain.Abstractions;

public interface IConcurrencyEntity
{
    int Revision { get; set; }
}
