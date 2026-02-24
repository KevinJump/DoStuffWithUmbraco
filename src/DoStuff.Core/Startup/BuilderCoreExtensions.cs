using DoStuff.Core.Data;
using DoStuff.Core.Data.Persistance;
using DoStuff.Core.Data.Services;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Startup;

internal static class BuilderCoreExtensions
{
    public static IUmbracoBuilder AddDoStuffCore(this IUmbracoBuilder builder)
    {
        builder.AddDoStuffDataLayer();

        return builder;
    }
}
