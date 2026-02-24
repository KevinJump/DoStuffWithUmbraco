using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

namespace DoStuff.Client.Composers;

/// <summary>
///  Package Manifest reader is a way of adding the package via backend code.
/// </summary>
/// <remarks>
///  a package manifest reader is registerd in the composer, add adds 
///  the package details via the backend c# code. 
///  
///  Adding the package this way means we can set the version of the package
///  to match the version in the assembly. so when we release a new version
///  the package version is automatically updated.
///  
///  we can also add this to the URL of the script file, so we bust the 
///  cache for any new version of the package.
/// </remarks>
internal class DoStuffPackageManifestReader : IPackageManifestReader
{
    public Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync()
    {
        var version = Assembly.GetAssembly(typeof(DoStuffPackageManifestReader))?.GetName().Version?.ToString() ?? "1.0.0";

        return Task.FromResult<IEnumerable<PackageManifest>>(new[]
        {
            new PackageManifest
            {
                Id = "DoStuff.Client",
                Name = "DoStuff with Umbraco client",
                AllowTelemetry = true,
                Version = version,
                Extensions = [
                    new {
                        name = "DoStuff Client Bundle",
                        alias = "DoStuff.Client.Bundle",
                        type = "bundle",
                        js = "/App_Plugins/DoStuffClient/do-stuff-client.js?v=" + version
                    }
                ]
            }
        });
    }
}

