using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DoStuff.Core.Configuration;
using DoStuff.Core.Controllers;

using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Infrastructure.WebAssets;
using Umbraco.Extensions;

namespace DoStuff.Core.Events
{
    public class DoStuffServerVariablesNotifcationHandler : INotificationHandler<ServerVariablesParsing>
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
        public void Handle(ServerVariablesParsing notification)
        {

            notification.ServerVariables.Add("DoStuff", new Dictionary<string, object>
            {
                { "MagicNumber", _options.MagicNumber },
                { "DoStuffApiBaseUrl", _linkGenerator.GetUmbracoApiServiceBaseUrl<DoStuffApiController>(c => c.GetMagicNumber()) }
            });
        }
    }
}
