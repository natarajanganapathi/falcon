global using System;
global using System.Collections.Generic;
global using System.Data;
global using System.Linq;
global using System.Reflection;
global using System.Threading;
global using System.Threading.Tasks;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.JsonPatch;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Storage;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;

global using Newtonsoft.Json.Linq;

global using Falcon.Contracts;
global using Falcon.Infrastructure.Abstractions;
global using Falcon.Infrastructure.EntityFramework.QueryBuilder;
global using Falcon.Infrastructure.EntityFramework.Abstractions.Configurations;
global using Falcon.Infrastructure.EntityFramework.Abstractions.Contexts;
global using Falcon.Infrastructure.EntityFramework.Abstractions.Contexts.HomeDb;
global using Falcon.Infrastructure.EntityFramework.Abstractions.Contexts.TenantDb;
global using Falcon.Infrastructure.EntityFramework.Abstractions.Repository;
global using Falcon.Infrastructure.EntityFramework.Abstractions.HealthCheck;

global using Falcon.Domain.Abstractions.Attributes;
global using Falcon.Domain.Abstractions.Interfaces.Repositories;
global using Falcon.Domain.Abstractions.Interfaces.Entities;
