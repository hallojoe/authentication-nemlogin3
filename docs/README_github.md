# Casko.Authentication.NemLogin3.Web

[![Downloads](https://img.shields.io/nuget/dt/Casko.Authentication.NemLogin3.Web?color=cc9900)](https://www.nuget.org/packages/Casko.Authentication.NemLogin3.Web/)
[![NuGet](https://img.shields.io/nuget/vpre/Casko.Authentication.NemLogin3.Web?color=0273B3)](https://www.nuget.org/packages/Casko.Authentication.NemLogin3.Web)

Reusable ASP.NET Core support for NemLog-in 3 / OIOSAML 3 SAML authentication.

The public NuGet package is `Casko.Authentication.NemLogin3.Web`. It provides the shared SAML foundation for applications that need NemLog-in 3 authentication without binding the implementation to a specific CMS, host, or member model.

## Installation

```powershell
dotnet add package Casko.Authentication.NemLogin3.Web
```

## Package Focus

- Configure ITfoxtec Identity SAML2 from application configuration.
- Load NemLog-in IdP metadata and service provider certificates.
- Generate service provider metadata for NemLog-in registration.
- Provide standalone ASP.NET Core login, assertion consumer, single logout, and logged-out endpoints.
- Normalize common NemLog-in / OIOSAML claim values through claim constants and a transformer hook.

## Main Entry Points

- `AddNemLogin3Saml(...)` registers reusable SAML configuration, metadata services, HTTP client setup, and claim transformation.
- `AddNemLogin3Web(...)` registers the shared SAML services plus the standalone MVC endpoints.
- `UseNemLogin3Web(...)` wires the standalone ASP.NET Core middleware pipeline.

Use `AddNemLogin3Saml(...)` when another authentication layer owns the user/session experience. Use `AddNemLogin3Web(...)` and `UseNemLogin3Web(...)` when the package should expose its standalone MVC endpoints directly.

## Maintainer Notes

- Keep this package host-agnostic.
- Keep project-specific user mapping, authorization, account persistence, and UI behavior outside this package.
- Keep changes centered on the reusable NemLog-in 3 SAML layer: metadata, endpoints, certificates, options, and claims.
- Full solution and package documentation lives in `docs`.
