using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Cms.Web.Common.Routing;

namespace DoStuff.Core.Api.ToDo;

[ApiController]
[Authorize(Policy = AuthorizationPolicies.BackOfficeAccess)]
[MapToApi(apiName: DoStuffApiConstants.ApiName)]
public class ToDoControllerBase 
{
}
