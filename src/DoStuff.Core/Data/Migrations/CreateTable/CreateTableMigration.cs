using DoStuff.Core.Data.Persistence.Models;
using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Data.Migrations.CreateTable;

/// <summary>
///  craete database tables as part of a migration.
/// </summary>
internal class CreateTableMigration : MigrationBase
{
	public CreateTableMigration(IMigrationContext context)
		: base(context)
	{
	}

	protected override void Migrate()
	{
		if (!TableExists(DataConstants.ToDoListTableName))
			Create.Table<ToDoListDTO>().Do();

		if (!TableExists(DataConstants.ToDoItemTableName))
			Create.Table<ToDoItemDTO>().Do();
	}
}
