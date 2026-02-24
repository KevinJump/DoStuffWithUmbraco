using DoStuff.Core.Startup;

using Microsoft.Extensions.DependencyInjection;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Infrastructure.Manifest;

namespace DoStuff.Client.Composers;

[ComposeAfter(typeof(DoStuffCoreComposer))]
public class DoStuffClientApiComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        // add the client api to the Umbraco builder, this will add all the necessary services and configuration for our API controllers to work
        builder.AddDoStuffClientApi();

        // add the package manifest for the client, so we don't use umbraco-package.json file
        builder.Services.AddSingleton<IPackageManifestReader, DoStuffPackageManifestReader>();
    }
}

