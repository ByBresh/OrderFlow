# .NET 10.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET 10.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10.0 upgrade.
3. Upgrade OrderFlow.ServiceDefaults\OrderFlow.ServiceDefaults.csproj
4. Upgrade OrderFlow.Identity\OrderFlow.Identity.csproj
5. Upgrade OrderFlow.Front\orderflow.front.esproj
6. Upgrade OrderFlow\OrderFlow.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

Table below contains projects that do belong to the dependency graph for selected projects and should not be included in the upgrade.

| Project name | Description |
| :--- | :--- |
| | |

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name | Current Version | New Version | Description |
| :--- | :--- | :--- | :--- |
| Aspire.Hosting.AppHost | 9.5.0 | 13.0.0 | Recommended for .NET 10.0 |
| Aspire.Hosting.PostgreSQL | 9.5.2 | 13.0.0 | Recommended for .NET 10.0 |
| Microsoft.AspNetCore.Authentication.JwtBearer | 9.0.0 | 10.0.0 | Recommended for .NET 10.0 |
| Microsoft.AspNetCore.Identity.EntityFrameworkCore | 9.0.10 | 10.0.0 | Recommended for .NET 10.0 |
| Microsoft.AspNetCore.OpenApi | 9.0.10 | 10.0.0 | Recommended for .NET 10.0 |
| Microsoft.EntityFrameworkCore.Design | 9.0.10 | 10.0.0 | Recommended for .NET 10.0 |
| Microsoft.Extensions.Http.Resilience | 8.10.0 | 10.0.0 | Recommended for .NET 10.0 |
| Microsoft.Extensions.ServiceDiscovery | 8.2.2 | 10.0.0 | Recommended for .NET 10.0 |
| Microsoft.VisualStudio.Azure.Containers.Tools.Targets | 1.22.1 | | Incompatible |
| OpenTelemetry.Instrumentation.AspNetCore | 1.9.0;1.13.0 | 1.14.0 | Recommended for .NET 10.0 |
| OpenTelemetry.Instrumentation.Http | 1.9.0 | 1.14.0 | Recommended for .NET 10.0 |

### Project upgrade details
This section contains details about each project upgrade and modifications that need to be done in the project.

#### OrderFlow.ServiceDefaults\OrderFlow.ServiceDefaults.csproj modifications

Project properties changes:
- Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
- Microsoft.Extensions.Http.Resilience should be updated from `8.10.0` to `10.0.0`
- Microsoft.Extensions.ServiceDiscovery should be updated from `8.2.2` to `10.0.0`
- OpenTelemetry.Instrumentation.AspNetCore should be updated from `1.9.0` to `1.14.0`
- OpenTelemetry.Instrumentation.Http should be updated from `1.9.0` to `1.14.0`

#### OrderFlow.Identity\OrderFlow.Identity.csproj modifications

Project properties changes:
- Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
- Microsoft.VisualStudio.Azure.Containers.Tools.Targets should be removed
- Microsoft.AspNetCore.Authentication.JwtBearer should be updated from `9.0.0` to `10.0.0`
- Microsoft.AspNetCore.Identity.EntityFrameworkCore should be updated from `9.0.10` to `10.0.0`
- Microsoft.AspNetCore.OpenApi should be updated from `9.0.10` to `10.0.0`
- Microsoft.EntityFrameworkCore.Design should be updated from `9.0.10` to `10.0.0`
- OpenTelemetry.Instrumentation.AspNetCore should be updated from `1.13.0` to `1.14.0`

#### OrderFlow.Front\orderflow.front.esproj modifications

Project properties changes:
- Target framework should be changed from `net6.0` to `net10.0`

#### OrderFlow\OrderFlow.csproj modifications

Project properties changes:
- Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
- Aspire.Hosting.AppHost should be updated from `9.5.0` to `13.0.0`
- Aspire.Hosting.PostgreSQL should be updated from `9.5.2` to `13.0.0`
