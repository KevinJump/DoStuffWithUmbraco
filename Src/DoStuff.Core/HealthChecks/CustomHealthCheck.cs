using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Composing;
using Umbraco.Web;
using Umbraco.Web.HealthCheck;

namespace DoStuff.Core
{
    /// <summary>
    /// Register the healthcheck 
    /// </summary>
    public class CustomHealthCheckComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.HealthChecks().Add<CustomHealthCheck>();
        }
    }

    /// <summary>
    ///  Simple health check, that counts to 100 - because it can
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
            switch(action.Alias)
            {
                case "count":
                    return ExecuteCount();
            }

            return null;
        }

        public override IEnumerable<HealthCheckStatus> GetStatus()
        {
            yield return GetCountStatus();
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
            for(int i = 0; i < 100; i++)
            {
                //counting...
            }

            return new HealthCheckStatus("Counted to 100");
        }
    }
}
