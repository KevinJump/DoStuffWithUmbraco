using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using DoStuff.Core.FileDownload;

using Umbraco.Core.Composing;
using Umbraco.Web;
using Umbraco.Web.JavaScript;

namespace DoStuff.Core.FileUpload
{
    /// <summary>
    ///  fileDownload Composer / Component
    /// </summary>
    /// <remarks>
    ///  You don't need a composer/component to register 
    ///  the file download controller, 
    ///  
    ///  we are just doing this to add the URL of the ApiController
    ///  to the javascript variables in Umbraco.Sys.ServerVariables
    ///  
    ///  this is nice to do because then the URL you refrence in your
    ///  angular controller is determained at runtime, so if someone
    ///  installs umbraco in a subfolder it will all still work. 
    ///  
    ///  you probibly won't have multiple composers across your project
    ///  like we do here, you can put all your variables in a single
    ///  parsing event if you want.
    /// </remarks>

    public class FileDownloadComposer
        : ComponentComposer<FileDownloadComponent>
    { }

    public class FileDownloadComponent : IComponent
    {
        public void Initialize()
        {
            ServerVariablesParser.Parsing += ServerVariablesParser_Parsing;
        }

        /// <summary>
        ///  called at startup when the javascript server variables are being
        ///  built.
        /// </summary>
        private void ServerVariablesParser_Parsing(object sender, Dictionary<string, object> e)
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException("This method requires that an HttpContext be active");

            var urlHelper = new UrlHelper(new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData()));

            e.Add("doStuffFileDownload", new Dictionary<string, object>
            {
                { "downloadService", urlHelper.GetUmbracoApiServiceBaseUrl<DoStuffDownloadApiController>(controller => controller.GetApi()) }
            });

        }

        public void Terminate()
        {
            // closing down
        }
    }
}
