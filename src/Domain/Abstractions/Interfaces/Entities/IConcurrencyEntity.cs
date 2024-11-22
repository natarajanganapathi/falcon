namespace Falcon.Domain.Abstractions.Interfaces.Entities;

public interface IConcurrencyEntity
{
    int Revision { get; set; }
}
