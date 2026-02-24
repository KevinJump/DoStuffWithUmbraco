using Microsoft.Extensions.Logging;

using NPoco;

using Umbraco.Cms.Infrastructure.Migrations;

namespace DoStuff.Core.Data.Persistance.Migrations.ExecuteSql;

internal class ExecuteSqlMigration : AsyncMigrationBase
{
    public ExecuteSqlMigration(IMigrationContext context)
        : base(context) { }

    protected override async Task MigrateAsync()
    {
        int count = await Database.ExecuteScalarAsync<int>(new Sql($"Select * from {DoStuffConstants.TimeSettingsTableName}"));

        if (Context.Logger.IsEnabled(LogLevel.Information))
            Context.Logger.LogInformation("Count of records in {TableName} is {Count}", DoStuffConstants.TimeSettingsTableName, count);
    }
}
