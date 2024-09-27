namespace Falcon.Messaging;

public class MessagingOptionsBuilder
{
    private Action<MediatRServiceConfiguration> _mediatRConfiguration = cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    private Action<IBusRegistrationConfigurator>? _busRegistrationConfigurator = null;

    public static MessagingOptionsBuilder New() => new();

    public MessagingOptionsBuilder MediatRConfiguration(Action<MediatRServiceConfiguration> mediatRConfiguration)
    {
        _mediatRConfiguration = mediatRConfiguration;
        return this;
    }

     public MessagingOptionsBuilder BusRegistrationConfigurator(Action<IBusRegistrationConfigurator> busRegistrationConfigurator)
    {
        _busRegistrationConfigurator = busRegistrationConfigurator;
        return this;
    }

    public MessagingOptions Build()
    {
        return new MessagingOptions
        {
            MediatRConfiguration = _mediatRConfiguration,
            BusRegistrationConfigurator = _busRegistrationConfigurator
        };
    }
}
