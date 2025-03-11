using DoStuff.Core.NotificationHandlers;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core;

public static class DoStuffCoreBuilderExtensions
{
    public static IUmbracoBuilder AddDoStuffCore(this IUmbracoBuilder builder)
    {
        builder.AddDoStuffNotificationHandlers();
        return builder;
    }
}
