using DoStuff.Core.Notifications.Models;

using Microsoft.Extensions.Logging;

using Umbraco.Cms.Core.Events;

namespace DoStuff.Core.Notifications;

internal class TimeSettingsSavedNotificationHandler : INotificationAsyncHandler<TimeSettingsSavedNotification>
{
    private readonly ILogger<TimeSettingsSavedNotificationHandler> _logger;

    public TimeSettingsSavedNotificationHandler(ILogger<TimeSettingsSavedNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(TimeSettingsSavedNotification notification, CancellationToken cancellationToken)
    {
        if (_logger.IsEnabled(LogLevel.Information))
            _logger.LogInformation("Notification : Time settings saved: {@TimeSettings}", notification.TimeSettings);

        return Task.CompletedTask;
        
    }
}
