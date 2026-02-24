using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Persistance.Repositories;
using DoStuff.Core.Notifications.Models;

using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Scoping;

namespace DoStuff.Core.Data.Services;

internal class TimeSettingsService : DoStuffServiceBase<TimeSettings>, ITimeSettingsService
{
    private readonly ITimeSettingsRepository _repository;

    private readonly IEventAggregator _eventAggregator;

    public TimeSettingsService(
        ITimeSettingsRepository timeSettingsRepository,
        ICoreScopeProvider coreScopeProvider,
        IEventAggregator eventAggregator)
        : base(timeSettingsRepository, coreScopeProvider)
    {
        _repository = timeSettingsRepository;
        _eventAggregator = eventAggregator;
    }

    public async Task<TimeSettings?> GetByUser(Guid key)
    {
        using (_scopeProvider.CreateCoreScope(autoComplete: true))
        {
            return await _repository.GetByUserAsync(key);
        }
    }

    public override async Task<TimeSettings?> SaveAsync(TimeSettings model)
    {
        var result = await base.SaveAsync(model);

        // example of firing a notification, this could be used to trigger other actions in the system when time settings are saved
        await _eventAggregator.PublishAsync(new TimeSettingsSavedNotification(model));

        return result;
    }
}
