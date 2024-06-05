namespace LightningArc.Domain.Abstractions;

public interface IMultiTenantEntity<TId>
{
    TId TenantId { get; set; }
}
