namespace Falcon.Contracts;

public class FieldFilter : ConditionFilter, IFieldFilter
{
    public FieldFilter(string field, FieldOperator op, object value, FilterValueType? type = default) : base(field, FilterType.Field)
    {
        Op = op;
        Value = value;
        Type = type;
    }
    public FieldOperator Op { get; set; }
    public object? Value { get; set; }
    public FilterValueType? Type { get; set; }
}
