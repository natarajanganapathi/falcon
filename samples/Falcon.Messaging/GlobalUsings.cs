global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Routing;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Http.HttpResults;
global using System.Reflection;
global using Falcon.Messaging;
global using Falcon.Messaging.DomainEvents;
global using Falcon.Messaging.ApplicationEvents;
global using Falcon.Messaging.IntegrationEvents;
global using Falcon.Messaging.Query;
global using Falcon.Messaging.Command;

global using MassTransit;

global using Samples.Falcon.Messaging;
global using Samples.Falcon.Messaging.Events.ApplicationEvents;
global using Samples.Falcon.Messaging.Events.DomainEvents;
global using Samples.Falcon.Messaging.Events.IntegrationEvents;
global using Samples.Falcon.Messaging.Events.Query;
global using Samples.Falcon.Messaging.Events.Command;
global using Samples.Falcon.Messaging.WeatherForecast;
