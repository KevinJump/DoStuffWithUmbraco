using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace DoStuff.Core.Api.Configuration;

/// <summary>
/// Add DoStuff swagger config 
/// </summary>
/// <remarks>
///  you can do this from the builder.services, e.g
///  <code>
///   builder.services.AddSwaggerGen
///  </code>
///  but this method seperates it out and makes it easier to manage.
/// </remarks>
internal class DoStuffSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        options.SwaggerDoc(
			DoStuffApiConstants.ApiName,
            new OpenApiInfo
            {
                Title = "DoStuff Management Api",
                Version = "1.0",
                Description = "Examples of Management Api Controllers"
            });

        // for "simple" api controllers, you can  set the operation id to the method
        // names. As long as you don't overload your methods this will work fine
        // options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"]}");

        // for completeness, we have an IOperationsFilter which handles overloaded methods.
        options.OperationFilter<DoStuffSwaggerOperationFilter>();
	}
}
