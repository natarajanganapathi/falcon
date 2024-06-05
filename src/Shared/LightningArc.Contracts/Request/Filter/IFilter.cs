namespace LightningArc.Contracts;

public interface IFilter
{
    FilterType Kind { get; set; }
}
public interface ICompositeFilter : IFilter
{
    CompositeOperator Op { get; set; }
    Filter[]? Filters { get; set; }
}

public interface IConditionFilter : IFilter
{
    string Field { get; set; }
}

public interface IFieldFilter : IConditionFilter
{
    FieldOperator Op { get; set; }
    object? Value { get; set; }
    FilterValueType? Type { get; set; }
}

public interface IUnaryFilter : IConditionFilter
{
    UnaryOperator Op { get; set; }
}
