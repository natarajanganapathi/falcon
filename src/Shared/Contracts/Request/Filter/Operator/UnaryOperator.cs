namespace Falcon.Contracts;

public enum UnaryOperator
{
    [EnumMember(Value = "null")] IsNull,
    [EnumMember(Value = "notnull")] IsNotNull
}
