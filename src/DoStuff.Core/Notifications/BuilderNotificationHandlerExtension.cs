using DoStuff.Core.Notifications.Models;

using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace DoStuff.Core.Notifications;

internal static class BuilderNotificationHandlerExtension
{
    public static IUmbracoBuilder AddDoStuffNotificationHandlers(this IUmbracoBuilder builder)
    {
        // umbraco notifications
        builder.AddNotificationAsyncHandler<ContentSavedNotification, ContentSavedNotificationHandler>();

        // custom notifications
        builder.AddNotificationAsyncHandler<TimeSettingsSavedNotification, TimeSettingsSavedNotificationHandler>();

        return builder;
    }
}
