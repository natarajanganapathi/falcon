namespace Falcon.Domain.Abstractions.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class TenantDbAttribute : Attribute { }
