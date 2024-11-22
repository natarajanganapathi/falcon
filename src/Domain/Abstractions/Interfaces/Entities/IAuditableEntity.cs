namespace Falcon.Domain.Abstractions.Interfaces.Entities;

public interface IAuditableEntity
{
    DateTime CreatedAtUtc { get; set; }
    IUserId? CreatedByUserId { get; set; }
    DateTime ModifiedAtUtc { get; set; }
    IUserId? ModifiedByUserId { get; set; }
}
