using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DoStuff.Core.FileUpload;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Umbraco.Web.WebApi;

namespace DoStuff.Core.SignalR
{
    /// <summary>
    ///  example of how you can use signalR inside your controllers, to 
    ///  update a user of progress as a thing happes. 
    /// </summary>
    public class DoStuffSignalRApiController : UmbracoAuthorizedApiController
    {

        /// <summary>
        ///  An Api Controller method that signals progress back to the client
        ///  via SignalR - good for long running things.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public bool MyMessageMethod(ThingModel model)
        {
            // get the context of our hub
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<DoStuffHub>();

            if (hubContext != null && !string.IsNullOrWhiteSpace(model.ClientId))
            {
                // get the speific client, we only want to send the 
                // message back to the user who asked us for it.
                var client = hubContext.Clients.Client(model.ClientId);
                if (client != null)
                {
                    // dynamics - the 'Hello' is the eventName in js
                    // it can be whatever you want it to be.
                    // and you can send objects back, they will be JSON
                    // at the other end.
                    client.Hello($"Message from an Api Controller {DateTime.Now}");
                    return true;
                }
            }

            return false;
        }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ThingModel
    {
        public string Thing { get; set; }
        public string ClientId { get; set; }
    }
}
