# Casko.Authentication.NemLogin3.Web

NemLog-in 3 integration should not start from a blank SAML canvas every time.

`Casko.Authentication.NemLogin3.Web` gives ASP.NET Core projects a focused foundation for NemLog-in 3 / OIOSAML 3 authentication. It packages the repeatable work around service provider metadata, certificate-backed SAML configuration, login and logout endpoints, and normalized NemLog-in claims so projects can spend more time on their own user experience and less time wiring protocol plumbing.

## What It Gives You

- A reusable ASP.NET Core package for NemLog-in 3 SAML authentication.
- Service provider metadata generation for NemLog-in registration.
- Ready-made login, assertion consumer, single logout, and logged-out endpoints.
- Certificate-backed signing and decryption support through ITfoxtec Identity SAML2.
- Claim constants and a default transformation hook for common NemLog-in / OIOSAML claim values.
- A host-agnostic design that can be used by standalone ASP.NET Core applications or wrapped by higher-level authentication packages.

## Why Use It

NemLog-in 3 integrations are sensitive to metadata, certificates, URLs, claim names, and SAML endpoint conventions. This package brings those concerns into one reusable layer with clear extension points, making it easier to build repeatable Danish identity integrations across projects.

The package is intentionally not tied to a specific CMS, website, or member model. It provides the SAML foundation and leaves project-specific user mapping, authorization, and account behavior to the host application.

## Install

```powershell
dotnet add package Casko.Authentication.NemLogin3.Web
```

For implementation details, configuration examples, and maintainer notes, see the source repository documentation.
