using DoStuff.Core.Data.Models;

namespace DoStuff.Core.Data.Persistance.Repositories;

public interface ITimeSettingsRepository : IDoStuffRepositoryBase<TimeSettings>
{
    Task<TimeSettings?> GetByUserAsync(Guid userKey);
}