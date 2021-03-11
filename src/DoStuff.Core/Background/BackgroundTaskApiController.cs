
using Microsoft.AspNetCore.Mvc;

using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;

namespace DoStuff.Core.Background
{
    [PluginController("DoStuff")]
    public class BackgroundTaskApiController : UmbracoAuthorizedApiController
    {
        public readonly BackgroundQueuingTask _backgroundQueuingTask;

        public BackgroundTaskApiController(BackgroundQueuingTask queuedBackgroundTask)
        {
            this._backgroundQueuingTask = queuedBackgroundTask;
        }

        [HttpGet]
        public bool GetApi() => true;

        /// <summary>
        ///  queue a task to run on a background thread.
        /// </summary>

        // umbraco/backoffice/DoStuff/BackgroundTaskApi/QueueBackgroundTask?message=hello
        [HttpGet]
        public void QueueBackgroundTask(string message)
        {
            _backgroundQueuingTask.QueueBackgroundThing(message);
        }
    }
}
