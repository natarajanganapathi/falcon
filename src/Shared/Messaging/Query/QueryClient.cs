namespace Falcon.Messaging.Query;

public class QueryClient
{
    private readonly IServiceProvider _serviceProvider;

    public QueryClient(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> GetAsync<TResponse>(object requeset, CancellationToken cancellationToken = default) where TResponse : class
    {
        var query = _serviceProvider.GetRequiredService<IRequestClient<TResponse>>();
        var response = await query.GetResponse<TResponse>(requeset);
        return response.Message;
    }
}
