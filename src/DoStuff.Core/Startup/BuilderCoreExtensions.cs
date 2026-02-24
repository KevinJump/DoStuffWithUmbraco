using DoStuff.Core.Data;
using DoStuff.Core.Data.Persistance;
using DoStuff.Core.Data.Services;
using DoStuff.Core.Notifications;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Startup;

internal static class BuilderCoreExtensions
{
    public static IUmbracoBuilder AddDoStuffCore(this IUmbracoBuilder builder)
    {
        // the services, repo, etc for data 
        builder.AddDoStuffDataLayer();
        
        // something to handle events. 
        builder.AddDoStuffNotificationHandlers();

        return builder;
    }
}
