using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Persistance.Models;

using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Infrastructure.Scoping;
using Umbraco.Extensions;

namespace DoStuff.Core.Data.Persistance.Repositories;

internal class TimeSettingsRepository : DoStuffRepositoryBase<TimeSettingsDTO, TimeSettings>, ITimeSettingsRepository
{
    public TimeSettingsRepository(
        IScopeAccessor scopeAccessor,
        IUmbracoMapper mapper) 
        : base(scopeAccessor, mapper, DoStuffConstants.TimeSettingsTableName)
    { }

    public async Task<TimeSettings?> GetByUserAsync(Guid userKey)
    {
        var sql = GetBaseQuery(false)
            .Where<TimeSettingsDTO>(x => x.UserKey == userKey);

        var results = await Database.FirstOrDefaultAsync<TimeSettingsDTO>(sql);
        if (results == null) return default;

        return Mapper.Map<TimeSettingsDTO, TimeSettings>(results);
    }
}
