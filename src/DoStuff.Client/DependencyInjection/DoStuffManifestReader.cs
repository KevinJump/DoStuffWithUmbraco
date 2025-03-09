using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

namespace DoStuff.Client.DependencyInjection;
internal static class DoStuffManifestReaderBuilderExtensions
{
    public static IUmbracoBuilder AddDoStuffManifestReader(this IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<IPackageManifestReader, DoStuffManifestReader>();
        return builder;
    }
}

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

    



