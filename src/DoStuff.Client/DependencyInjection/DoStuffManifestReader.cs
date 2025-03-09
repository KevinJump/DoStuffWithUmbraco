using Microsoft.Extensions.DependencyInjection;

using System.Text.Json.Nodes;

using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

namespace DoStuff.Client.DependencyInjection;

/// <summary>
///  Extension point so the manifest reader can be added to a composer. 
/// </summary>
/// <example>
/// <code>
///     builder.AddDoStuffManifestReader();
/// </code>
/// </example>
internal static class DoStuffManifestReaderBuilderExtensions
{
    public static IUmbracoBuilder AddDoStuffManifestReader(this IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<IPackageManifestReader, DoStuffManifestReader>();
        return builder;
    }
}

/// <summary>
///  package manifest reader, adds the manifest for the package directly to the loaded 
///  list of manifests (bypassing the need for an umbraco-package.json file.
/// </summary>
/// <remarks>
///  the advantage of this method is that you can use the version of the compiled code 
///  in the package, so you don't have to do any build steps to manually alter a json
///  file. 
///  
///  you can also add the version as query parameter to the javascript file and this 
///  helps break any caching issues that might occur when you update the package.
/// </remarks>
internal class DoStuffManifestReader : IPackageManifestReader
{
    public Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync()
    {
        var versionString = typeof(DoStuffManifestReader).Assembly.GetName().Version?.ToString(3) ?? "0.0.0";

        List<PackageManifest> manifests = [
            new PackageManifest
                {
                    Id = "DoStuff.Client",
                    Name = "DoStuff.Client",
                    Version = versionString,
                    AllowTelemetry = true,
                    Extensions = [
                        new JsonObject {
                            ["name"] = "DoStuff Client Bundle",
                            ["alias"] = "DoStuff.Client.Bundle",
                            ["type"] = "bundle",
                            ["js"] = $"/App_Plugins/DoStuffClient/do-stuff-client.js?version={versionString}"
                        }]
                }
        ];

        return Task.FromResult(manifests.AsEnumerable());
    }
}