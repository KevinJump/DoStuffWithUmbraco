using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Persistance.Repositories;

using Umbraco.Cms.Core.Scoping;

namespace DoStuff.Core.Data.Services;

internal class TimeSettingsService : DoStuffServiceBase<TimeSettings>, ITimeSettingsService
{
    private readonly ITimeSettingsRepository _repository;

    public TimeSettingsService(
        ITimeSettingsRepository timeSettingsRepository,
        ICoreScopeProvider coreScopeProvider)
        : base(timeSettingsRepository, coreScopeProvider)
    { 
        _repository = timeSettingsRepository;
    }

    public async Task<TimeSettings?> GetByUser(Guid key)
    {
        using (_scopeProvider.CreateCoreScope(autoComplete: true))
        {
            return await _repository.GetByUserAsync(key);
        }
    }
}
