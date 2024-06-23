namespace LightningArc.Persistence.EntityFramework.QueryBuilder.Exceptions;

public class QueryBuilderException : Exception
{
    public QueryBuilderException(string message) : base(message) { }
    public QueryBuilderException(string message, Exception innerException) : base(message, innerException) { }
}