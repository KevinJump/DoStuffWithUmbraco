using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

using Umbraco.Cms.Infrastructure.HostedServices;

namespace DoStuff.Core.Background
{
    /// <summary>
    ///  a background task that runs at regular intervals. 
    /// </summary>

    // TODO: Review in build
    // Current Build : 9.0.0-beta001.20210307.3 
    // THIS Doesn't work as you can't override the internal method
    // https://github.com/umbraco/Umbraco-CMS/pull/9295#issuecomment-796867478
    //
    // Also probibly needs MainDom passing so we know if we are running in the 
    // correct location.
    // 
    /* 
    public class RecurringBackgroundTask : RecurringHostedServiceBase
    {
        // setup for every thirty minutes
        public RecurringBackgroundTask() 
            : base(TimeSpan.FromMinutes(30), DefaultDelay)
        {
        }

        internal override Task PerformExecuteAsync(object state)
        {
            // run your code here.

            return Task.CompletedTask;
        }
    }
    */
}
