using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Data.Migrations.AddIndex;

/// <summary>
///  Add an index to an existing table.
/// </summary>
/// <remarks>
///  if you add the index to the model then it will be
///  setup as part of the create table migration.
///  
///  if you have added the index to a site that has 
///  already got the tables then this migration will add
///  it. 
///  
///  but if its a first time install, the other migration
///  will have done it and this one will simply exit. 
/// </remarks>
internal class AddIndexToTableMigration : MigrationBase
{
	public AddIndexToTableMigration(IMigrationContext context)
		: base(context)
	{
	}

	protected override void Migrate()
	{
		// this migration only runs if the table exists 
		if (TableExists(DataConstants.ToDoItemTableName) == false)
			return;

		// if the index exsits we don't need to add it again. 
		if (IndexExists("IX_ToDoItemKeyIndex")) return;

		// add the index.
		Create.Index("IX_ToDoItemKeyIndex")
			.OnTable(DataConstants.ToDoItemTableName)
			.OnColumn("Key")
			.Unique()
			.WithOptions().NonClustered()
			.Do();
	}
}
