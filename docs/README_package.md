# Casko.Authentication.NemLogin3.Web

`Casko.Authentication.NemLogin3.Web` is the reusable ASP.NET Core package in this solution. It owns the NemLog-in 3 / OIOSAML 3 SAML foundation: configuration, service provider metadata, endpoint wiring, certificates, and claim normalization.

The package should stay host-agnostic. Project-specific user mapping, authorization rules, account persistence, CMS integrations, and UI behavior belong in host applications or wrapper packages.

## Responsibility

- Configure `ITfoxtec.Identity.Saml2` from the `Saml2` and `NemLogin3` configuration sections.
- Load NemLog-in IdP metadata and the service provider signing/decryption certificate.
- Generate service provider metadata for NemLog-in registration.
- Provide standalone MVC login, assertion consumer, single logout, and logged-out endpoints.
- Normalize raw SAML claims into a common claim shape consumed by host applications.

## Main Entry Points

- `NemLogin3WebExtensions.AddNemLogin3Saml(...)`
  Registers reusable SAML configuration, metadata service, HTTP client setup, and claim transformation.

- `NemLogin3WebExtensions.AddNemLogin3Web(...)`
  Registers the shared SAML services plus the standalone MVC controllers.

- `NemLogin3WebExtensions.UseNemLogin3Web(...)`
  Wires the standalone ASP.NET Core middleware pipeline, including forwarded headers, static files, routing, SAML session support, and authorization.

Use `AddNemLogin3Saml(...)` when another authentication layer owns the user/session behavior. Use `AddNemLogin3Web(...)` and `UseNemLogin3Web(...)` when the package should expose its standalone endpoints directly.

## Code Map

- `Configuration/NemLogin3Options.cs`
  Options for public service provider URLs, endpoint paths, requested NSIS LoA, metadata contact details, and requested attributes.

- `Configuration/NemLogin3ClaimConstants.cs`
  NemLog-in/OIOSAML claim URI constants, including CPR UUID, full name, NSIS LoA, CVR, and organization name.

- `Configuration/NemLogin3WebExtensions.cs`
  DI and middleware extension methods. This is where certificate loading, IdP metadata reading, SAML destinations, accepted issuers, and signature validation certificates are configured.

- `Controllers/AuthController.cs`
  Standalone SAML login, assertion consumer service, and logout controller. It creates signed AuthnRequests, validates SAML responses, transforms claims, and creates a local ASP.NET session.

- `Controllers/MetadataController.cs`
  Standalone `/Metadata` endpoint.

- `Services/NemLogin3MetadataService.cs`
  Builds service provider metadata, including ACS, SLO, signing/encryption certificates, NameID format, and requested attributes.

- `Services/DefaultNemLogin3ClaimsTransformer.cs`
  Default hook for normalizing SAML claims. Keep this generic; host-specific member/user mapping belongs outside this project.

## Configuration Shape

The host must provide:

```json
{
  "NemLogin3": {
    "PublicBaseUrl": "https://samlcasko0001.dev.localhost",
    "MetadataPath": "/Metadata",
    "LoginPath": "/Auth/Login",
    "AssertionConsumerServicePath": "/Auth/AssertionConsumerService",
    "SingleLogoutPath": "/Auth/SingleLogout",
    "LoggedOutPath": "/Auth/LoggedOut",
    "RequestedAuthnContext": "https://data.gov.dk/concept/core/nsis/loa/Substantial"
  },
  "Saml2": {
    "Issuer": "https://samlcasko0001.dev.localhost",
    "IdPMetadataFile": "oiosaml3-idp-devtest4-inttest-25-11-26.xml",
    "SigningCertificateFile": "oces3_-test-_systemcertifikat.p12",
    "SigningCertificatePassword": "..."
  }
}
```

`PublicBaseUrl` and `Saml2:Issuer` must match the service provider registration at NemLog-in. `Saml2:Issuer` becomes the SAML metadata entity ID, so metadata generation fails if it is missing.

## Maintainer Notes

- The standalone `AuthController` intentionally does not set `AssertionConsumerServiceURL` on the AuthnRequest. The registered service provider metadata declares the ACS.
- The metadata service does not sign the metadata document itself; it emits metadata using the configured SAML certificate and ITfoxtec metadata types.
- In DEBUG, the default HTTP client accepts any server certificate to support local development metadata/certificate flows.
- Do not add CMS dependencies to this package.
