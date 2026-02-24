using NPoco;

using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace DoStuff.Core.Data.Persistance.Models;

[TableName(DoStuffConstants.TimeSettingsTableName)]
[PrimaryKey("id")]
[ExplicitColumns]
internal class TimeSettingsDTO : ItemBaseDTO
{
    [Column("UserKey")]
    public required Guid UserKey { get; set; }

    [Column("RefreshInterval")]
    public int RefreshInterval { get; set; }

    [Column("TimeZones")]
    [SpecialDbType(SpecialDbTypes.NVARCHARMAX)]
    [NullSetting(NullSetting = NullSettings.Null)]
    public string? TimeZones { get; set; }

    [Column("Comment")]
    [SpecialDbType(SpecialDbTypes.NVARCHARMAX)]
    [NullSetting(NullSetting = NullSettings.Null)]
    public string? Comment { get; set; }
}
