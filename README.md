## Dotnet Tools

The following global tools are required

```sh
LightningArc> dotnet tool list -g

Package Id                      Version         Commands
-------------------------------------------------------------------
coverlet.console                       6.0.0           coverlet
docfx                                  2.75.2          docfx
dotnet-counters                        8.0.505301      dotnet-counters
dotnet-coverage                        17.10.1         dotnet-coverage    
dotnet-doc                             1.0.4           docs
dotnet-ef                              8.0.1           dotnet-ef
dotnet-format                          5.1.250801      dotnet-format      
dotnet-monitor                         8.0.0           dotnet-monitor     
dotnet-outdated-tool                   4.6.0           dotnet-outdated    
dotnet-reportgenerator-globaltool      5.2.5           reportgenerator    
dotnet-sonarscanner                    6.1.0           dotnet-sonarscanner
dotnet-version-cli                     3.0.3           dotnet-version     
husky                                  0.6.2           husky
mscl                                   1.0.0           mscl
nbgv                                   3.6.133         nbgv
pipelinetrigger                        1.0.0           mptd
swashbuckle.aspnetcore.cli             6.5.0           swagger
versionize                             1.21.0          versionize
```


## Architecure References
1. [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture)
2. [Clean Architecture](https://github.com/amantinband/clean-architecture)

## Development Refernce
1. [Endpoint Groupgings](https://www.linkedin.com/feed/update/urn:li:activity:7071491219628912640/)
2. [Implement Keycloak Authentication](https://medium.com/@ahmed.gaduo_93938/how-to-implement-keycloak-authentication-in-a-net-core-application-ce8603698f24#:~:text=How%20to%20Implement%20Keycloak%20Authentication%20in%20a%20.NET,Endpoints%20...%206%20Step%206%3A%20Handle%20Authentication%20Callbacks)


## DDD

### Application
#### Application Events Raised from Application layer
    1. UserLoggedIn
    2. UserLoggedOut
    3. SessionExpired
    4. PasswordChanged
#### Raised from Infrastructure Components
    5. UserRegistered
    6. CacheRefreshed
    7. ApplicationStarted
    8. ApplicationShutdown
### Domain
    Domain Events
    1. OrderPlaced
    2. PaymentProcessed
    3. ItemShipped

### Infrastructure
    Integration Events: (communication between different bounded contexts)


### Background Tasks

### Shared Kernal

1. [DDD Reference](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)
2. [Sample Source Reference](https://github.com/dotnet-architecture/eShopOnContainers/tree/main/src/Services/Ordering/Ordering.API)
3. [Builder Pattern](https://www.youtube.com/watch?v=qCIr30WxJQw&t=8s)