using Umbraco.Cms.Core.Notifications;

namespace DoStuff.Core.Notifications.Models;

internal class TimeSettingsSavedNotification : INotification
{
    public TimeSettingsSavedNotification(Data.Models.TimeSettings timeSettings)
    {
        TimeSettings = timeSettings;
    }

    public Data.Models.TimeSettings TimeSettings { get; }

}
