namespace LightningArc.Infrastructure.EntityFramework.QueryBuilder.Exceptions;

[Serializable]
public class QueryBuilderException : Exception
{
    public QueryBuilderException(string message) : base(message) { }
    public QueryBuilderException(string message, Exception innerException) : base(message, innerException) { }
}