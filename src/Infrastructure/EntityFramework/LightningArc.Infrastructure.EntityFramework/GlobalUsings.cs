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

global using LightningArc.Contracts;
global using LightningArc.Infrastructure.Abstractions;
global using LightningArc.Infrastructure.EntityFramework.Configurations;
global using LightningArc.Infrastructure.EntityFramework.Contexts;
global using LightningArc.Infrastructure.EntityFramework.Contexts.HomeDb;
global using LightningArc.Infrastructure.EntityFramework.Contexts.TenantDb;
global using LightningArc.Infrastructure.EntityFramework.HealthCheck;

global using LightningArc.Domain.Abstractions.Interfaces.Repositories;
global using LightningArc.Domain.Abstractions.Interfaces.Entities;
global using LightningArc.Infrastructure.Abstractions.Attributes;
global using LightningArc.Infrastructure.EntityFramework.QueryBuilder;
