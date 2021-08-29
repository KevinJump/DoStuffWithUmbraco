using DoStuff.Core.Configuration;
using DoStuff.Core.Controllers;

using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

using System.Collections.Generic;

using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace DoStuff.Core.Events
{
    public class DoStuffServerVariablesNotifcationHandler : INotificationHandler<ServerVariablesParsingNotification>
    {
        private DoStuffOptions _options;
        private LinkGenerator _linkGenerator;

        public DoStuffServerVariablesNotifcationHandler(
            LinkGenerator linkGenerator,
            IOptions<DoStuffOptions> options)
        {
            _linkGenerator = linkGenerator;
            _options = options.Value;
        }

        /// <summary>
        ///  Adds extra info to the server variables javascript object.
        /// </summary>
        /// <remarks>
        ///  values will be accessible in javascript via Umbraco.Sys.ServerVariables.DoStuff object.
        /// </remarks>
        public void Handle(ServerVariablesParsingNotification notification)
        {
            notification.ServerVariables.Add("DoStuff", new Dictionary<string, object>
            {
                { "MagicNumber", _options.MagicNumber },
                { "DoStuffApiBaseUrl", _linkGenerator.GetUmbracoApiServiceBaseUrl<DoStuffApiController>(c => c.GetMagicNumber()) }
            });
        }
    }
}
