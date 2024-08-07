namespace Falcon.Contracts;

public class Sort : ISort
{
    public Sort(string field, Direction direction)
    {
        Field = field;
        Direction = direction;
    }
    public string Field { get; set; }
    public Direction Direction { get; set; }
}
