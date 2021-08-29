
using DoStuff.Core.Configuration;
using DoStuff.Core.Events;
using DoStuff.Core.Services;

using Microsoft.Extensions.DependencyInjection;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace DoStuff.Core
{
    public class DoStuffComposer : IUserComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            // Add Options 
            builder.Services.Configure<DoStuffOptions>(builder.Config.GetSection(DoStuffOptions.DoStuffSection));

            // Add services
            builder.Services.AddUnique<DoStuffService>();

            // Add Event handlers
            builder.AddNotificationHandler<ServerVariablesParsingNotification, DoStuffServerVariablesNotifcationHandler>();
            builder.AddNotificationHandler<ContentSavedNotification, DoStuffContentNotificationHandler>(); 
        }
    }
}
