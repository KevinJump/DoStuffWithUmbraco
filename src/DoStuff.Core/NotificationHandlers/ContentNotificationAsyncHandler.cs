using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace DoStuff.Core.NotificationHandlers;

internal class ContentNotificationAsyncHandler :
    INotificationAsyncHandler<ContentSavingNotification>,
    INotificationAsyncHandler<ContentSavedNotification>
{

    /// <summary>
    ///  ContentSavingNotification - Fires when content is saving. (but not yet saved).
    /// </summary>
    /// <remarks>
    ///  you can cancel a 'saving' notification and it will stop the operation in umbraco. 
    /// </remarks>
    public Task HandleAsync(ContentSavingNotification notification, CancellationToken cancellationToken)
    {
        foreach(var entity in notification.SavedEntities)
        {
            if (entity.Name?.Contains("stop", StringComparison.InvariantCultureIgnoreCase) is true)
            {
                notification.CancelOperation(new EventMessage("Blocked", "You cannot save content with the word 'stop' in the name", EventMessageType.Error));
                notification.Cancel = true;

                return Task.CompletedTask;
            }

            if (entity.Name?.Contains("pass", StringComparison.InvariantCultureIgnoreCase) is true)
            {
                // you can also store things in the notification state, so they can be passed between
                // as '...ing' and '..ed' state
                notification.State["HasPass"] = true;
            }
        }

        return Task.CompletedTask;

    }

    /// <summary>
    ///  handles when an content item has been saved
    /// </summary>
    /// <remarks>
    ///  Save will also file when something is being published 
    /// </remarks>
    public Task HandleAsync(ContentSavedNotification notification, CancellationToken cancellationToken)
    {
        if (notification.State.TryGetValue("HasPass", out var hasPass) is true || hasPass is true)
        {
            // the content has a 'pass' in it, so we might do something different here. 
        }

        foreach(var entity in notification.SavedEntities)
        {
            // process each saved entity in the notification.
        }

        return Task.CompletedTask;
    }
}
