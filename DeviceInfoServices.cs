using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DotNative.Plugins;

public interface IDeviceInfo
{
    int IosMajorVersion { get; }
}

public static class DeviceInfoServices
{
    public static IServiceCollection AddDeviceInfo(this IServiceCollection services)
    {
        services.TryAddSingleton<IDeviceInfo, NativeDeviceInfo>();
        return services;
    }
}

internal sealed class NativeDeviceInfo : IDeviceInfo
{
    public int IosMajorVersion => DeviceInfo.IosMajorVersion;
}
