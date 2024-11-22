namespace Falcon.Messaging.MassTransit.Query;

public class QueryClient
{
    private readonly IServiceProvider _serviceProvider;

    public QueryClient(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> GetAsync<TRequest, TResponse>(TRequest requeset, CancellationToken cancellationToken = default) where TRequest : class, IQuery where TResponse : class
    {
        var query = _serviceProvider.GetRequiredService<IRequestClient<TRequest>>();
        var response = await query.GetResponse<TResponse>(requeset, cancellationToken);
        return response.Message;
    }
}
