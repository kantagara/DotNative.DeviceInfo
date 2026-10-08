# DotNative.DeviceInfo

An optional NuGet plugin with its own C# project and Objective-C implementation.
Reference it from a DotNative.App project, then read
`DotNative.Plugins.DeviceInfo.IosMajorVersion`. No Xcode edits or copied native
files are needed. The app tooling discovers its MSBuild native-source declaration,
compiles the source and links its C export into the application. This implementation
supports iOS only; other OS calls throw PlatformNotSupportedException.

## Service access

Import `DotNative.Plugins` to access the plugin through `IServiceProvider`:

```csharp
using DotNative.Plugins;

var plugin = services.DeviceInfo;
```

The getter calls `GetRequiredService<IDeviceInfo>()` on every access, preserving
DI lifetimes and the usual missing-registration error. Register the plugin with
`AddDeviceInfo(...)` before building the provider.

A `net10.0` application uses the property syntax with C# 14 or later. A
`net9.0` application uses only the method equivalent:

```csharp
var plugin = services.DeviceInfo();
```

The package contains separate `net9.0` and `net10.0` assemblies. NuGet selects
the assembly matching the application target framework. `NET10_0_OR_GREATER`
selects the property; the `#else` branch selects the method.

Build and pack both targets with .NET 10 SDK. A source build using .NET 9 SDK
builds only `net9.0`; it does not produce the .NET 10 assembly.
