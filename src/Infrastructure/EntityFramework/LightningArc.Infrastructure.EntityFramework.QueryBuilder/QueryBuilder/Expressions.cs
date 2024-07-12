namespace LightningArc.Infrastructure.EntityFramework.QueryBuilder;

public static class Expressions
{
    public static Expression Parse(object? value, Type type)
    {
        var parseMethod = type.GetMethod("Parse", [Types.StringType])
            ?? throw new QueryBuilderException($"Type {type} does not have Parse method");
        return Expression.Call(parseMethod, Expression.Constant(value));
    }
    public static Expression ToDateOnly(object value)
    {
        return Parse(value, typeof(DateOnly));
    }
    public static Expression ToUniversalTime(object value)
    {
        return Expression.Call(Parse(value, Types.DateTimeType), "ToUniversalTime", null);
    }
}