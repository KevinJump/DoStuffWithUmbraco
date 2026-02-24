using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Data.Persistance.Migrations.AddIndex;

internal class AddIndexToTableMigration : AsyncMigrationBase
{
    public AddIndexToTableMigration(IMigrationContext context)
        : base(context)
    { }

    protected override Task MigrateAsync()
    {
        if (TableExists(DoStuffConstants.TimeSettingsTableName))
        {
            if (!IndexExists("IX_DoStuff_TimeSettings_Key"))
            { 
                Create.Index("IX_DoStuff_TimeSettings_Key")
                    .OnTable(DoStuffConstants.TimeSettingsTableName)
                    .OnColumn("Key")
                    .Unique()
                    .WithOptions().NonClustered()
                    .Do();
            }
        }

        return Task.CompletedTask;
    }
}
