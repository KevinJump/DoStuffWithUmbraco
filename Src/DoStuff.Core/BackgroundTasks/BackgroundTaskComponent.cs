using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Web.Scheduling;

namespace DoStuff.Core.BackgroundTasks
{
    public class BackgroundTaskComposer
        : ComponentComposer<BackgroundTaskComponent> { }

    public class BackgroundTaskComponent : IComponent
    {
        private readonly IProfilingLogger logger;
        private readonly IRuntimeState runtimeState;

        public BackgroundTaskComponent(IRuntimeState runtimeState, IProfilingLogger logger)
        {
            this.runtimeState = runtimeState;
            this.logger = logger;
        }

        public void Initialize()
        {
            // time in milliseconds
            var delay = 60 * 1000;  // how long after startup 
            var period = 180 * 1000; // (once every 3 minutes)

            // register background task
            var runner = new BackgroundTaskRunner<IBackgroundTask>("Custom Task", logger);
            if (runner != null)
            {
                var check = new CustomBackgroundTask(runner, delay, period, logger, runtimeState);
                runner.Add(check);
            }
        }

        public void Terminate()
        {
            // umbraco closing down
        }
    }
}
