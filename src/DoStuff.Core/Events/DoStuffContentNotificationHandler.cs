
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace DoStuff.Core.Events
{
    public class DoStuffContentNotificationHandler : INotificationHandler<ContentSavedNotification>
    {
        public void Handle(ContentSavedNotification notification)
        {
            foreach(var item in notification.SavedEntities)
            {
                // handle saved content here.
            }
        }
    }
}
