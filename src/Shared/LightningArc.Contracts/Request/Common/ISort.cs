namespace LightningArc.Contracts;

public interface ISort
{
    string Field { get; set; }
    Direction Direction { get; set; }
}

public enum Direction
{
    [EnumMember(Value = "ASC")] Ascending,
    [EnumMember(Value = "DESC")] Descending
}