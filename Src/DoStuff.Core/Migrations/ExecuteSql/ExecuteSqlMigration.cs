using NPoco;

using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Migrations
{
    /// <summary>
    ///  execute some SQL against the db.
    /// </summary>
    /// <remarks>
    ///  it is important to remember that this code will
    ///  run once Umbraco has gathered all the required 
    ///  steps of a migration together, it doesn't run in place
    ///  
    ///  so for example you can't say i want to update a value
    ///  and expect that value quariable in code for the next
    ///  migration to run, because the SQL is ran at the end in 
    ///  a batch. 
    /// </remarks>
    public class ExecuteSqlMigration : MigrationBase
    {
        public ExecuteSqlMigration(IMigrationContext context)
            : base(context)
        {
        }

        public override void Migrate()
        {
            if (TableExists(DoStuff.Tables.MySimpleTable))
            {
                Database.Execute(new Sql($"SELECT Id from {DoStuff.Tables.MySimpleTable}"));
            }
        }
    }
}
