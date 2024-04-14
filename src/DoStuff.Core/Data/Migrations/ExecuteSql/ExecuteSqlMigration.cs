using NPoco;

using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Data.Migrations.ExecuteSql;

/// <summary>
///  run arbitrary SQL as part of a migration
/// </summary>
internal class ExecuteSqlMigration : MigrationBase
{
	public ExecuteSqlMigration(IMigrationContext context) : base(context)
	{
	}

	protected override void Migrate()
	{
		// we can't run SQL on a table if it isn't there.
		if (TableExists(DataConstants.ToDoItemTableName) is false)
			return;

		// i mean don't run SQL where you have just made the string up!
		// but if you need to run commands you can do it like this.
		Database.Execute(new Sql($"SELECT Id from {DataConstants.ToDoItemTableName}"));
	}
}
