namespace Falcon.Contracts;

public interface ICommandResponse<TEntity> : IApiResponse
{
    TEntity? Data { get; set; }
}

