using Microsoft.Extensions.Logging;

using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace DoStuff.Core.Notifications;

/// <summary>
///  Simple notification handler that runs when content is saved. 
/// </summary>
/// <remarks>
///  the notification handler is registered in a composer (see BuilderNotificationHandlerExtension) and will run when the ContentSavedNotification is triggered in umbraco.
/// </remarks>
public class ContentSavedNotificationHandler : INotificationAsyncHandler<ContentSavedNotification>
{
    public readonly ILogger<ContentSavedNotificationHandler> _logger;

    public ContentSavedNotificationHandler(ILogger<ContentSavedNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(ContentSavedNotification notification, CancellationToken cancellationToken)
    {
        if (_logger.IsEnabled(LogLevel.Information))
            _logger.LogInformation("Notification: Content with Id {ContentId} has been saved", notification.SavedEntities.Select(x => x.Id));
        
        return Task.CompletedTask;
    }
}
