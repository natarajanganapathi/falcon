namespace Falcon.Domain.Abstractions.Interfaces.Entities;

public interface IMultiTenantEntity<TId>
{
    TId TenantId { get; set; }
}
