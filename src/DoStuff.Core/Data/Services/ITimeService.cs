namespace DoStuff.Core.Data.Services;

public interface ITimeService
{
    DateTime GetCurrentTime();
    IEnumerable<TimeZoneInfo> GetTimeZones();
    DateTime GetTimeZoneTime(string? id);
}