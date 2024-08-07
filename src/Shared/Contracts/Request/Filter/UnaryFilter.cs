namespace Falcon.Contracts;

public class UnaryFilter : ConditionFilter, IUnaryFilter
{
    public UnaryFilter(string field, UnaryOperator op) : base(field, FilterType.Unary)
    {
        Op = op;
    }
    public UnaryOperator Op { get; set; }
}
