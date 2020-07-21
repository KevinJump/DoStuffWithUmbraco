using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

using Umbraco.Web.WebApi;

namespace DoStuff.Core.FileDownload
{
    public class DoStuffDownloadApiController : UmbracoAuthorizedApiController
    {
        [HttpGet]
        public bool GetApi() => true;

        /// <summary>
        ///  Download a file example
        /// </summary>
        /// <remarks>
        ///  if you still want to use umbRequestHelper
        ///  then you can add items to the query string, if you want to send more complex
        ///  data you will need to copy and use your own downloadFile function in your javascript
        /// </remarks>
        [HttpGet]
        public HttpResponseMessage DownloadText(string message, int count)
        {
            if (string.IsNullOrWhiteSpace(message) || count == 0)
                return new HttpResponseMessage(HttpStatusCode.NoContent);
                    
            // work out the content of the file you want to return here
            var content = string.Concat(Enumerable.Repeat($"{message}\r\n", count));
            var contentBytes = Encoding.ASCII.GetBytes(content);

            // assuming you have some bytes to return ...

            var response = new HttpResponseMessage
            {
                Content = new ByteArrayContent(contentBytes)
                {
                    Headers =
                    {
                        ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = "repeating.txt"
                        },
                        ContentType = new MediaTypeHeaderValue("text/plain")
                    }
                }
            };
            response.Headers.Add("x-filename", "repeating.txt");
            return response;

        }
    }
}
