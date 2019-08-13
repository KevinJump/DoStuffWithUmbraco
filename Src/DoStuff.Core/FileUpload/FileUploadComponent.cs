using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Umbraco.Core.Composing;
using Umbraco.Web;
using Umbraco.Web.JavaScript;

namespace DoStuff.Core.FileUpload
{
    /// <summary>
    ///  fileUpload Composer / Component
    /// </summary>
    /// <remarks>
    ///  You don't need a composer/component to register 
    ///  the file upload controller, 
    ///  
    ///  we are just doing this to add the URL of the ApiController
    ///  to the javascript variables in Umbraco.Sys.ServerVariables
    ///  
    ///  this is nice to do because then the URL you refrence in your
    ///  angular controller is determained at runtime, so if someone
    ///  installs umbraco in a subfolder it will all still work. 
    /// 
    /// </remarks>

    public class FileUploadComposer 
        : ComponentComposer<FileUploadComponent>
    { }

    public class FileUploadComponent : IComponent
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

            e.Add("doStuffFileUpload", new Dictionary<string, object>
            {
                { "uploadService", urlHelper.GetUmbracoApiServiceBaseUrl<DoStuffUploadApiController>(controller => controller.GetApi()) }
            });

        }

        public void Terminate()
        {
            // closing down
        }
    }
}
