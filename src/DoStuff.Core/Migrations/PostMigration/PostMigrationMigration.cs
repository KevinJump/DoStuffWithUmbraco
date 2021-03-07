
using Microsoft.Extensions.Logging;

using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Migrations
{
    /// <summary>
    ///  run things at the end of a migration. 
    /// </summary>
    /// <remarks>
    ///  by default migrations are batched, that is umbraco
    ///  goes through all the required migrations and works 
    ///  out what all the SQL is going to be. 
    ///  
    ///  the code you execute here actuall happes before any
    ///  of the migrations have been ran.
    ///  
    ///  if you want to run code after the migrations you need
    ///  a post migration action. 
    ///  
    ///  these can be added to the runner, but the best way 
    ///  is to add them in a migration that requires them
    ///  
    ///  this way you know it will only run once. 
    /// </remarks>
    public class PostMigrationMigration : MigrationBase
    {
        public PostMigrationMigration(IMigrationContext context) 
            : base(context)
        {
        }

        public override void Migrate()
        {
            Context.Logger.LogInformation("Post Migration Migration Code Ran");
            Context.AddPostMigration<RebuildSomething>();
            Context.Logger.LogInformation("Post Migration Added");
        }
    }

    public class RebuildSomething : IMigration
    {
        private readonly ILogger logger;

        public RebuildSomething(IMigrationContext context)
        {
            this.logger = context.Logger;
        }

        public void Migrate()
        {
            logger.LogInformation("Post Migration Step Ran");
        }
    }
}
