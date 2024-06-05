namespace LightningArc.QueryBuilder;

public class QueryBuilderException : Exception
{
    public QueryBuilderException(string message) : base(message) { }
    public QueryBuilderException(string message, Exception innerException) : base(message, innerException) { }
}