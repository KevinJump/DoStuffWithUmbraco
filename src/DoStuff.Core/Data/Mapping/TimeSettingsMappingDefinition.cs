using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Persistance.Models;

using System.Text.Json;

using Umbraco.Cms.Core.Mapping;

namespace DoStuff.Core.Data.Mapping;

internal class TimeSettingsMappingDefinition : IMapDefinition
{
    public void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TimeSettings, TimeSettingsDTO>(
            (source, context) => new TimeSettingsDTO()
            {
                Key = source.Key != Guid.Empty ? source.Key : Guid.NewGuid(),
                UserKey = source.UserKey,
                TimeZones = JsonSerializer.Serialize(source.TimeZones)
            },
            (source, target, context) =>
            {
                target.Id = source.Id;
                target.Key = source.Key != Guid.Empty ? source.Key : Guid.NewGuid();
                target.UserKey = source.UserKey;
                target.RefreshInterval = source.RefreshInterval;
                target.TimeZones = JsonSerializer.Serialize(source.TimeZones);
            });

        mapper.Define<TimeSettingsDTO, TimeSettings>(
            (source, context) => new TimeSettings()
            {
                Key = source.Key,
                UserKey = source.UserKey,
            },
            (source, target, context) =>
            {
                target.Id = source.Id;
                target.Key = source.Key;
                target.UserKey = source.UserKey;
                target.RefreshInterval = source.RefreshInterval;
                target.TimeZones = JsonSerializer.Deserialize<List<TimeZoneSetting>>(source.TimeZones ?? "[]") ?? [];
            });
    }
}
