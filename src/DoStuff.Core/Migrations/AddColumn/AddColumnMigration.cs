
using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Migrations
{
    public class AddColumnMigration : MigrationBase
    {
        public AddColumnMigration(IMigrationContext context) 
            : base(context)
        {
        }

        protected override void Migrate()
        {
        
            if (TableExists(DoStuff.Tables.MySimpleTable))
            {
                // table is here 

                if (!ColumnExists(DoStuff.Tables.MySimpleTable, "myNewColumn"))
                {
                    // column isn't 

                    // create it 
                    Create.Column("myNewColumn")
                            .OnTable(DoStuff.Tables.MySimpleTable)
                            .AsString()
                            .Nullable()
                            .Do();
                }
            }
        }
    }
}
