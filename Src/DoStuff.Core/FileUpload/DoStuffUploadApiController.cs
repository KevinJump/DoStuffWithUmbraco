using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Core.IO;
using Umbraco.Web.WebApi;

namespace DoStuff.Core.FileUpload
{
    public class DoStuffUploadApiController : UmbracoAuthorizedApiController
    {
        /// <summary>
        ///  simple call, used to locate the controller
        ///  when we inject it into the javascript varibles.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetApi() => "Hello";

        /// <summary>
        ///  upload a file to a folder in app_data
        /// </summary>
        /// <returns>name of the file</returns>
        [HttpPost]
        public async Task<string> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var uploadFolder = IOHelper.MapPath("~/App_Data/Temp/DoStuffUploads/");
            Directory.CreateDirectory(uploadFolder);

            var provider = new CustomMultipartFormDataStreamProvider(uploadFolder);
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            var filename = result.FileData.First().LocalFileName;

            var someId = result.FormData["someId"];

            if (filename == null)
                throw new HttpResponseException(HttpStatusCode.NoContent);

            // at this point filename points to the local file uploaded into the folder
            // you can manipulate it at will :)

            return Path.GetFileNameWithoutExtension(filename);
        }
    }

    /// <summary>
    ///  by using a custom multipart provider we can also send form data with the file
    ///  which is useful when you have other things to say too. 
    /// </summary>

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) : base(path) { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
        }
    }

}
