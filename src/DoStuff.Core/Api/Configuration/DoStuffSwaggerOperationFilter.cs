using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace DoStuff.Core.Api.Configuration;

/// <summary>
///  operations filter to ensure clean unqiue names for our methods. 
/// </summary>
/// <remarks>
/// <see cref="https://g-mariano.medium.com/generate-readable-apis-clients-by-setting-unique-and-meaningful-operationid-in-swagger-63d404f32ff8"/>
/// </remarks>
internal class DoStuffSwaggerOperationFilter : IOperationFilter
{
    private readonly Dictionary<string, string> _operationIds = new();

	public void Apply(OpenApiOperation operation, OperationFilterContext context)
	{
        if (context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor is false)
            return;

        if (_operationIds.TryGetValue(controllerActionDescriptor.Id, out string? value))
        {
            operation.OperationId = value;
            return;
        }

        // find the next free id for the method (e.g MyMethod2, MyMethod3, etc).
        var operationIdBaseName = $"{controllerActionDescriptor.ControllerName}_{controllerActionDescriptor.ActionName}";
        var operationId = operationIdBaseName;
        var suffix = 2;
        while (_operationIds.Values.Contains(operationId))
        {
            operationId = $"{operationIdBaseName}{suffix++}";
        }

        _operationIds[controllerActionDescriptor.Id] = operationId;

	}
}