global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Reflection;
global using System.Threading;
global using System.Threading.Tasks;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.JsonPatch;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;

global using Newtonsoft.Json.Linq;

global using LightningArc.Contracts;
global using LightningArc.Persistence.Abstractions;
global using LightningArc.Persistence.EntityFramework.Configuration;
global using LightningArc.Persistence.EntityFramework.Context;
global using LightningArc.Persistence.EntityFramework.HealthCheck;

global using LightningArc.QueryBuilder;
global using LightningArc.Domain.Abstractions;
