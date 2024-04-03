using Elsa.Caching.Features;
using Elsa.Features.Services;

// ReSharper disable once CheckNamespace
namespace Elsa.Extensions;

/// <summary>
/// Provides methods to install and configure the distributed caching feature.
/// </summary>
public static class ModuleExtensions
{
    /// <summary>
    /// Adds the <see cref="DistributedCacheFeature"/> feature to the system.
    /// </summary>
    public static IModule UseDistributedCaching(this IModule configuration, Action<MemoryCacheFeature>? configure = default)
    {
        configuration.Configure(configure);
        return configuration;
    }
}