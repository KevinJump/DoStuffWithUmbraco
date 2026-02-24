using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Data.Persistance.Migrations.AddColumn;

internal class AddColumnToTableMigration : AsyncMigrationBase
{
    public AddColumnToTableMigration(IMigrationContext context) : base(context)
    {
    }

    protected override Task MigrateAsync()
    {
        if (TableExists(DoStuffConstants.TimeSettingsTableName))
        {
            if (!ColumnExists(DoStuffConstants.TimeSettingsTableName, "Comment"))
            {
                Create.Column("Comment")
                    .OnTable(DoStuffConstants.TimeSettingsTableName)
                    .AsCustom("NTEXT")
                    .Nullable();
            }
        }

        return Task.CompletedTask;
    }
}
