using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Sync;
using Umbraco.Web.Scheduling;

namespace DoStuff.Core.BackgroundTasks
{
    public class CustomBackgroundTask : RecurringTaskBase
    {
        private readonly IProfilingLogger logger;

        public CustomBackgroundTask(
            IBackgroundTaskRunner<RecurringTaskBase> runner, int delayMilliseconds, int periodMilliseconds,
            IProfilingLogger logger) 
            : base(runner, delayMilliseconds, periodMilliseconds)
        {
            this.logger = logger;
        }

        public override bool IsAsync => true;


        public override Task<bool> PerformRunAsync(CancellationToken token)
        {
            if (RunOnThisServer())
            {
                logger.Info<CustomBackgroundTask>("Running our task");
            };

            // technically we shoud run things async for performances
            // because we are doing nothing here, just return the task.
            return Task.FromResult<bool>(true);
        }


        private bool RunOnThisServer()
        {
            // WARNING - we shouldn't be using Current !
            var role = Current.ServerRegistrar?.GetCurrentServerRole();
            if (role == null) return true;

            switch(role)
            {
                case ServerRole.Replica:
                    logger.Debug<CustomBackgroundTask>("Not running on a replica");
                    return false;
                case ServerRole.Unknown:
                    logger.Debug<CustomBackgroundTask>("Not running on a unknown server role");
                    return false;
                // case ServerRole.Master:
                // case ServerRole.Single:
                default:
                    logger.Debug<CustomBackgroundTask>("Running on master or single");
                    return true;
            }
        }
    }
}
