namespace Falcon.Domain.Abstractions.Interfaces.Entities;

public enum DeletableEntityStatus
{
    [EnumMember] Active = 1,
    [EnumMember] Deleted = 2
}
public interface IDeletableEntity
{
    DeletableEntityStatus Status { get; set; }
}
