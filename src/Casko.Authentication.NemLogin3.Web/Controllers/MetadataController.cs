using Casko.Authentication.NemLogin3.Web.Services;
using ITfoxtec.Identity.Saml2;
using ITfoxtec.Identity.Saml2.MvcCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Casko.Authentication.NemLogin3.Web.Controllers;

[AllowAnonymous]
[Route("Metadata")]
public class MetadataController(INemLogin3MetadataService metadataService) : Controller
{
    public IActionResult Index()
    {
        var entityDescriptor = metadataService.CreateMetadata(Request);
        return new Saml2Metadata(entityDescriptor).CreateMetadata().ToActionResult();
    }
}
