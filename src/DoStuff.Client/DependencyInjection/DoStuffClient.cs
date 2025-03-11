using Umbraco.Cms.Core.DependencyInjection;
using DoStuff.Client.DependencyInjection;

namespace DoStuff.Client.Composers;

public static class DoStuffClient
{
    public static IUmbracoBuilder AddDoStuffClient(this IUmbracoBuilder builder)
    {
        builder.AddDoStuffClientApi();
        builder.AddDoStuffManifestReader();
        return builder;
    }
}
