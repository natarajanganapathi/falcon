namespace Falcon.Contracts;

public enum FieldOperator
{
    [EnumMember(Value = "eq")] Equal,
    [EnumMember(Value = "ne")] NotEqual,
    [EnumMember(Value = "gt")] GreaterThan,
    [EnumMember(Value = "ge")] GreaterThanOrEqual,
    [EnumMember(Value = "lt")] LessThan,
    [EnumMember(Value = "le")] LessThanOrEqual,
    [EnumMember(Value = "bw")] Between,
    [EnumMember(Value = "in")] In,
    [EnumMember(Value = "notin")] NotIn,
    [EnumMember(Value = "ends")] EndsWith,
    [EnumMember(Value = "starts")] StartsWith,
    [EnumMember(Value = "contains")] Contains,
}