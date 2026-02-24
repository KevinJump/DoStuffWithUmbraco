using DoStuff.Core.Data.Persistance.Models;

using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Data.Persistance.Migrations.CreateTable;

internal class CreateTableMigration : AsyncMigrationBase
{
    public CreateTableMigration(IMigrationContext context) : base(context)
    {
    }

    protected override Task MigrateAsync()
    {
        if (!TableExists(DoStuffConstants.TimeSettingsTableName))
            Create.Table<TimeSettingsDTO>().Do();

        return Task.CompletedTask;
    }
}
