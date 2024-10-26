namespace Falcon.Infrastructure.EntityFramework.Abstractions.Contexts;

public abstract class ModelConfigurations
{
    public static void Configure<T>(ModelBuilder modelBuilder) where T : Attribute
    {
        var modelsType = AssemblyCache.Types
           .Where(t => !string.IsNullOrEmpty(t.Namespace) && t.GetCustomAttributes<T>().Any());
        foreach (var hmType in modelsType)
        {
            var configType = Array.Find(AssemblyCache.EntityTypeConfiguration,
                type =>
                {
                    var interfaces = type.GetInterfaces();
                    var genericArguments = interfaces
                        .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                        .Select(x => x.GetGenericArguments().FirstOrDefault())
                        .ToList();

                    return genericArguments.Contains(hmType);
                });

            if (configType != null)
            {
                modelBuilder.ApplyConfiguration(Activator.CreateInstance(configType) as dynamic);
            }
        }
    }
}