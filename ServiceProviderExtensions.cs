using System;
using Microsoft.Extensions.DependencyInjection;

namespace DotNative.Plugins;

public static class DeviceInfoServiceProviderExtensions
{
#if NET10_0_OR_GREATER
    extension(IServiceProvider services)
    {
        /// <summary>Resolves the registered plugin using the provider's DI lifetime.</summary>
        public IDeviceInfo DeviceInfo => services.GetRequiredService<IDeviceInfo>();
    }
#else
    /// <summary>Resolves the registered plugin using the provider's DI lifetime.</summary>
    public static IDeviceInfo DeviceInfo(this IServiceProvider services) =>
        services.GetRequiredService<IDeviceInfo>();
#endif
}
