using DoStuff.Core.Data.Migrations.AddColumn;
using DoStuff.Core.Data.Migrations.AddIndex;
using DoStuff.Core.Data.Migrations.CreateTable;
using DoStuff.Core.Data.Migrations.ExecuteSql;

using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Data.Migrations;

/// <summary>
///  A migration plan tells Umbraco hot to migrate
///  from one state to another, (e.g an upgrade)
/// </summary>
/// <remarks>
///  When executed an migration plan will cause
///  Umbraco to look in the UmbracoKeyValue table
///  for your app, and work out what the last
///  step was.
///  
///  then using the Migration plan it will perform
///  all the steps required to get to the end of 
///  the migration plan.
/// </remarks>
internal class DoStuffMigrationPlan : MigrationPlan
{
	public DoStuffMigrationPlan() 
		: base("DoStuffWithUmbraco") // name of your application/plan.
	{
		From(string.Empty) // nothing, a clean install.
			.To<CreateTableMigration>("DoStuff-CreateTables")
			.To<AddIndexToTableMigration>("DoStuff-AddIndex")
			.To<AddColumnMigration>("DoStuff-AddColumn")
			.To<ExecuteSqlMigration>("DoStuff-RunSql")
			;
	}
}
