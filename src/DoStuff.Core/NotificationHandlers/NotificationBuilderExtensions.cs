using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace DoStuff.Core.NotificationHandlers;

internal static class NotificationBuilderExtensions
{
    public static IUmbracoBuilder AddDoStuffNotificationHandlers(this IUmbracoBuilder builder)
    {
        // register our notification handlers to process things when something happens. 
        builder.AddNotificationAsyncHandler<ContentSavingNotification, ContentNotificationAsyncHandler>()
            .AddNotificationAsyncHandler<ContentSavedNotification, ContentNotificationAsyncHandler>();

        return builder;
    }
}
