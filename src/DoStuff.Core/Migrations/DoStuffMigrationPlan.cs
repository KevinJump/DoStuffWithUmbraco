
using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Migrations
{
    /// <summary>
    ///  A Migration plan, tells umbraco how to migrate from
    ///  one state to another
    /// </summary>
    /// <remarks>
    ///  when executed umbraco will look in the UmbracoKeyValue
    ///  table to work out if there are any existing migrations 
    ///  for your app.
    ///  
    ///  it then works out how to get from that step to the 
    ///  end of your plan.
    /// </remarks>
    public class DoStuffMigrationPlan : MigrationPlan
    {

        public DoStuffMigrationPlan()
            : base("DoStuffApplication")
        {
            // to actually see some of the things run,
            // you should comment them in, 

            // because on a new install things like the index 
            // and new column are added in the CreateTable Migration

            // so the AddColumn and AddIndex migrations run, but 
            // don't create because they are already there.

            From(string.Empty) // nothing installed. 
                .To<CreateTableMigration>("SimpleTable-Created")
                .To<AddColumnMigration>("NewColumn-Added")
                .To<AddIndexToTableMigration>("NewIndex-Added")
                .To<ExecuteSqlMigration>("CustomSql-Ran");
        }
    }
}
