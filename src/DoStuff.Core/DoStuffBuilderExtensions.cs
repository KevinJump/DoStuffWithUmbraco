using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core;

internal static class DoStuffBuilderExtensions
{
    public static IUmbracoBuilder AddDoStuff(this IUmbracoBuilder builder)
    {
        builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();
        return builder;
    }
}


internal class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        options.SwaggerDoc(
            name: "DoStuff",
            info: new OpenApiInfo
            {
                Title = "DoStuff Management Api",
                Version = "Latest",
                Description = "Example controllers from the DoStuff library"
            });
    }
}

