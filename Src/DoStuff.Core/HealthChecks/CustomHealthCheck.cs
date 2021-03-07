using System.Collections.Generic;
using System.Threading.Tasks;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.HealthChecks;
using Umbraco.Extensions;

namespace DoStuff.Core.HealthChecks
{
    /// <summary>
    ///  Register the health check
    /// </summary>
    public class CustomHealthCheckComposer : IUserComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.HealthChecks().Add<CustomHealthCheck>();
        }
    }

    /// <summary>
    ///  simple heath check - counts to 100, because it can.
    /// </summary>
    [HealthCheck("D5ADD41C-E9E9-434B-832D-282B237366C2",
           "Custom Health Checks",
           Description = "Some Custom Health Checks",
           Group = "DoStuff Checks")]
    public class CustomHealthCheck : HealthCheck
    {
        public CustomHealthCheck()
        {
        }

        public override HealthCheckStatus ExecuteAction(HealthCheckAction action)
        {
            switch (action.Alias)
            {
                case "count":
                    return ExecuteCount();
            }

            return null;
        }

        public override Task<IEnumerable<HealthCheckStatus>> GetStatus()
        {
            return Task.FromResult(GetCountStatus().AsEnumerableOfOne());
        }

        /// 
        private HealthCheckStatus GetCountStatus()
        {
            // this is where you check the status of your check 

            return new HealthCheckStatus("We haven't counted yet")
            {

                ResultType = StatusResultType.Warning,
                Description = "We like to count to 100",
                Actions = new List<HealthCheckAction>()
                {
                    new HealthCheckAction("count", this.Id)
                    {
                        Name = "Count to 100"
                    }
                }
            };
        }

        private HealthCheckStatus ExecuteCount()
        {
            // this is where you do the things to fix your check 
            for (int i = 0; i < 100; i++)
            {
                //counting...
            }

            return new HealthCheckStatus("Counted to 100");
        }
    }
}