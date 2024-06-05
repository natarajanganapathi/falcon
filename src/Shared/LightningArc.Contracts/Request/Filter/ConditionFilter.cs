namespace LightningArc.Contracts;

public class ConditionFilter : Filter, IConditionFilter
{
    public ConditionFilter(string field, FilterType filterType) : base(filterType)
    {
        Field = field;
    }
    public string Field { get; set; }
}
