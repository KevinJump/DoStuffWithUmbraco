using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Migrations;

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
