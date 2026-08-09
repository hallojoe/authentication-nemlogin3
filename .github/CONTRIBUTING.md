# Contributing Guidelines

Contributions are welcome.

This repository publishes `Casko.Authentication.NemLogin3.Web`, a reusable ASP.NET Core package for NemLog-in 3 / OIOSAML 3 SAML authentication. Please keep contributions focused on the package surface: SAML configuration, metadata generation, login/logout endpoints, certificates, options, and claim normalization.

Before opening a pull request:

- Build the package project in Release configuration.
- Keep public API changes intentional and documented.
- Avoid adding host-specific user mapping, CMS dependencies, account persistence, or UI behavior to the package.
- Include enough context in the pull request for reviewers to understand the NemLog-in 3 scenario being changed.
