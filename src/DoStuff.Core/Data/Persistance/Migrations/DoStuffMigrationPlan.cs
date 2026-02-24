using DoStuff.Core.Data.Persistance.Migrations.AddColumn;
using DoStuff.Core.Data.Persistance.Migrations.AddIndex;
using DoStuff.Core.Data.Persistance.Migrations.CreateTable;
using DoStuff.Core.Data.Persistance.Migrations.ExecuteSql;

using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Data.Persistance.Migrations;

internal class DoStuffMigrationPlan : MigrationPlan
{
    public DoStuffMigrationPlan() 
        : base(DoStuffConstants.ApplicationName)
    {
        From(string.Empty) // when nothing has been applied
            .To<CreateTableMigration>("create_table")
            .To<AddColumnToTableMigration>("add_column")
            .To<AddIndexToTableMigration>("add_index_to_table")
            .To<ExecuteSqlMigration>("execute_sql");

    }
}
