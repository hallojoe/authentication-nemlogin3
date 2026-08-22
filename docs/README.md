# Casko.Authentication.NemLogin3

`Casko.Authentication.NemLogin3` is a .NET 10 solution for reusable NemLog-in 3 / OIOSAML 3 SAML authentication support.

The primary output is the NuGet package `Casko.Authentication.NemLogin3.Web`. The other projects are local support projects used while developing and validating the package.

## Projects

| Project | Purpose |
| ------- | ------- |
| `src/Casko.Authentication.NemLogin3.Web` | Reusable ASP.NET Core package for SAML setup, service provider metadata, login/logout endpoints, certificates, and claim normalization. |
| `src/Casko.Authentication.NemLogin3.Web.UI` | Local runnable ASP.NET Core host used to validate the package with NemLog-in 3 test configuration. |
| `src/Casko.Authentication.NemLogin3.Web.Routing` | Local routing/proxy helper for development scenarios. It is not the package. |

The solution file is:

```text
src/Casko.Authentication.NemLogin3.slnx
```

## Prerequisites

- .NET 10 SDK
- A trusted ASP.NET Core HTTPS development certificate
- Local DNS/hosts setup for development hostnames such as `samlcasko0001.dev.localhost`
- NemLog-in 3 test metadata and service provider certificate files for the UI test host

Trust the development certificate once per machine:

```powershell
dotnet dev-certs https --trust
```

## Build

From the repository root:

```powershell
dotnet build src/Casko.Authentication.NemLogin3.slnx
```

Build the package project directly:

```powershell
dotnet build src/Casko.Authentication.NemLogin3.Web/Casko.Authentication.NemLogin3.Web.csproj --configuration Release
```

## Run The Local Test Host

Run the UI host:

```powershell
dotnet run --project src/Casko.Authentication.NemLogin3.Web.UI/Casko.Authentication.NemLogin3.Web.UI.csproj
```

The development launch profile opens:

```text
https://samlcasko0001.dev.localhost/
```

The service provider metadata endpoint is:

```text
https://samlcasko0001.dev.localhost/metadata
```

`NemLogin3:EntityId` is the unique value emitted as the metadata entity ID and should match `Saml2:Issuer`. `NemLogin3:PublicBaseUrl` controls the public ACS and SLO URLs and may include a port.

## Package Documentation

- `docs/README_package.md` contains maintainer and integration notes for `Casko.Authentication.NemLogin3.Web`.
- `docs/README_nuget.md` contains the buyer-facing NuGet package text.

## Notes

- Central package versions are managed in `src/Directory.Packages.props`.
- Keep the reusable package host-agnostic.
- Keep CMS-specific member mapping, account persistence, and UI behavior outside `Casko.Authentication.NemLogin3.Web`.
