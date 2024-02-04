using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Cms.Web.Common.Routing;

namespace DoStuff.Core.Controllers;

[ApiController]
[BackOfficeRoute("doStuff/api/v{version:apiVersion}")]
[Authorize(Policy = "New" + AuthorizationPolicies.BackOfficeAccess)]
[MapToApi("DoStuff")]
public class DoStuffControllerBase
{
}
