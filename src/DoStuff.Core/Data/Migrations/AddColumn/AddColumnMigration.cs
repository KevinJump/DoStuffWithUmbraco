using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Data.Migrations.AddColumn;

/// <summary>
///  Add a column to a table, that might have already been created.
/// </summary>
internal class AddColumnMigration : MigrationBase
{
	public AddColumnMigration(IMigrationContext context) : base(context)
	{
	}

	protected override void Migrate()
	{
		// if the table doesn't exist we can't add a column.
		if (TableExists(DataConstants.ToDoListTableName) is false)
			return;

		// if the column is already there we don't need to add it.
		if (ColumnExists(DataConstants.ToDoListTableName, "Owner"))
			return;

		Create.Column("Owner")
			.OnTable(DataConstants.ToDoListTableName)
			.AsString()
			.Nullable()
			.Do();
	}
}
