namespace Falcon.Contracts;

public class ContractException : Exception
{
    public ContractException() { }
    public ContractException(string message) : base(message) { }
    public ContractException(string message, Exception innerException) : base(message, innerException)
    { }
}
