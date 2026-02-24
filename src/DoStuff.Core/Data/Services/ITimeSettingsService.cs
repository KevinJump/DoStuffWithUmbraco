using DoStuff.Core.Data.Models;

namespace DoStuff.Core.Data.Services;

public interface ITimeSettingsService : IDoStuffServiceBase<TimeSettings>
{
    Task<TimeSettings?> GetByUser(Guid key);
}