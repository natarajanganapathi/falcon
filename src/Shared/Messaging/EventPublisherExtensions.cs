namespace Falcon.Messaging;

public static class EventPublisherExtensions
{
    private static IServiceProvider? _serviceProvider;

    internal static void Initialize(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static Task PublishAsync<TEvent>(this TEvent @event, CancellationToken cancellationToken = default) where TEvent : class, IEvent
    {
        IEventPublisher eventPublisher = @event switch
        {
            IApplicationEvent => _serviceProvider!.GetRequiredService<ApplicationEventPublisher>(),
            IDomainEvent => _serviceProvider!.GetRequiredService<DomainEventPublisher>(),
            IIntegrationEvent => _serviceProvider!.GetRequiredService<IntegrationEventPublisher>(),
            _ => throw new NotSupportedException($"Event type {typeof(TEvent).Name} is not supported.")
        };
        return eventPublisher.PublishAsync(@event, cancellationToken);
    }

    public static Task SendAsync<TEvent>(this TEvent @event, CancellationToken cancellationToken = default) where TEvent : class, ICommand
    {
        using var scope = _serviceProvider!.CreateScope();
        var commandSender = scope.ServiceProvider.GetRequiredService<CommandSender>();
        return commandSender.SendAsync(@event, cancellationToken);
    }

    public static Task<TResponse> GetAsync<TRequest, TResponse>(this TRequest @event, CancellationToken cancellationToken = default) where TRequest : class, IQuery where TResponse : class
    {
        using var scope = _serviceProvider!.CreateScope();
        var queryClient = scope.ServiceProvider.GetRequiredService<QueryClient>();
        return queryClient.GetAsync<TRequest, TResponse>(@event, cancellationToken);
    }
}