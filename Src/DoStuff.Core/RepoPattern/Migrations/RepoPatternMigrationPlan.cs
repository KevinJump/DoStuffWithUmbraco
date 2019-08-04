using DoStuff.Core.RepoPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Migrations;

namespace DoStuff.Core.RepoPattern.Migrations
{
    public class RepoPatternMigrationPlan : MigrationPlan
    {
        public RepoPatternMigrationPlan()
            : base("DoStuffRepoPattern")
        {

            From(string.Empty)
                .To<CreateMyListTableMigration>("MyListTable-Created");
        }
    }

    public class CreateMyListTableMigration : MigrationBase
    {
        public CreateMyListTableMigration(IMigrationContext context) 
            : base(context)
        {
        }

        public override void Migrate()
        {
            if (!TableExists(RepoPattern.MyListTable))
            {
                Create
                    .Table<MyList>()
                    .Do();
            }
        }
    }
}
