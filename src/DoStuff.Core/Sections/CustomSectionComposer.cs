
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace DoStuff.Core.Sections
{
    public class CustomSectionComposer : IUserComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Sections().Append<CustomSection>();

            builder.AddNotificationHandler<UmbracoApplicationStartingNotification, CustomSectionAppStartingHandler>();
        }
    }
}
