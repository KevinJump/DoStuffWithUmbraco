
using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Migrations
{
    public class AddIndexToTableMigration : MigrationBase
    {
        public AddIndexToTableMigration(IMigrationContext context) 
            : base(context)
        {
        }

        public override void Migrate()
        {
            if (TableExists(DoStuff.Tables.MySimpleTable))
            {
                if (!IndexExists("IX_mySimpleKeyIndex"))
                {
                    Create.Index("IX_mySimpleKeyIndex")
                        .OnTable(DoStuff.Tables.MySimpleTable)
                        .OnColumn("key")
                        .Unique()
                        .WithOptions().NonClustered()
                        .Do();
                }

            }
        }
    }
}
