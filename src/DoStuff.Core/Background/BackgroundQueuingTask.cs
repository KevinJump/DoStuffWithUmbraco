using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Umbraco.Cms.Infrastructure.HostedServices;

namespace DoStuff.Core.Background
{

    /// <summary>
    ///  allows you to queue a method to run as a background task. 
    /// </summary>
    /// <remarks>
    ///  umbraco has a backgroundTaskQueue that works through 
    ///  background task - so you don't have to worry about that bit.
    /// </remarks>
    public class BackgroundQueuingTask
    {
        private readonly IBackgroundTaskQueue _backgroundTaskQueue;
        private readonly ILogger<BackgroundQueuingTask> _logger;
        public BackgroundQueuingTask(
            IBackgroundTaskQueue backgroundTaskQueue,
            ILogger<BackgroundQueuingTask> logger)
        {
            this._backgroundTaskQueue = backgroundTaskQueue;
            this._logger = logger;
        }

        public void QueueBackgroundThing(string message)
        {
            _backgroundTaskQueue.QueueBackgroundWorkItem(
                cancellationToken => DoBackgroundThing(message, cancellationToken));
        }

        private Task DoBackgroundThing(string message, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Running background thing {message}", message);
            return Task.CompletedTask;
        }
    }
}
