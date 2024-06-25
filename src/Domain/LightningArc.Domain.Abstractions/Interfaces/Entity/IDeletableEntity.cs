namespace LightningArc.Domain.Abstractions;

public enum DeletableEntityStatus
{
    [EnumMember] Active = 1,
    [EnumMember] Deleted = 2
}
public interface IDeletableEntity
{
    DeletableEntityStatus Status { get; set; }
}
