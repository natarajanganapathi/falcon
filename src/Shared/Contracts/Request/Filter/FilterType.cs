namespace Falcon.Contracts;

public enum FilterType
{
    [EnumMember(Value = "c")] Composite,
    [EnumMember(Value = "f")] Field,
    [EnumMember(Value = "u")] Unary
}