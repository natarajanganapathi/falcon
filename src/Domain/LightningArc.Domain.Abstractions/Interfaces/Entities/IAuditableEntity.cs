namespace LightningArc.Domain.Abstractions.Interfaces.Entities;

public interface IAuditableEntity<TUserId>
{
    DateTime CreatedAtUtc { get; set; }
    TUserId CreatedByUserId { get; set; }
    DateTime ModifiedAtUtc { get; set; }
    TUserId ModifiedByUserId { get; set; }
}
