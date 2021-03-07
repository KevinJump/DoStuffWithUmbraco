
using DoStuff.Core.Models;

using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Migrations
{
    /// <summary>
    ///  creates a table in the DB if it's not already there
    /// </summary>
    public class CreateTableMigration : MigrationBase
    {
        public CreateTableMigration(IMigrationContext context) 
            : base(context)
        {
        }

        public override void Migrate()
        {
            if (!TableExists(DoStuff.Tables.MySimpleTable))
                Create.Table<MySimplePoco>().Do();
        }
    }
}
