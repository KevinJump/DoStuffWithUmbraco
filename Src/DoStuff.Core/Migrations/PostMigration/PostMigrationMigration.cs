using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Logging;
using Umbraco.Core.Migrations;

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
            Context.Logger.Info<PostMigrationMigration>("Post Migration Migration Code Ran");
            Context.AddPostMigration<RebuildSomething>();
            Context.Logger.Info<PostMigrationMigration>("Post Migration Added");
        }
    }

    public class RebuildSomething : IMigration
    {
        private readonly IProfilingLogger logger;

        public RebuildSomething(IProfilingLogger logger)
        {
            this.logger = logger;
        }

        public void Migrate()
        {
            logger.Info<RebuildSomething>("Post Migration Step Ran");
        }
    }
}
