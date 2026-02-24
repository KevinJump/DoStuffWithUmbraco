using Microsoft.Extensions.Logging;

namespace DoStuff.Core.Data.Services;

internal class TimeService : ITimeService
{
    private ILogger<TimeService> _logger;

    public TimeService(ILogger<TimeService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    ///  Retrieves the current time on the system
    /// </summary>
    /// <returns>the <see cref="DateTime"/> as set on the current system</returns>
    public DateTime GetCurrentTime() 
        => DateTime.Now;

    /// <summary>
    /// Retrieves the current time in the specified time zone.
    /// </summary>
    /// <param name="id">The identifier of the time zone.</param>
    /// <returns>The current <see cref="DateTime"/> in the specified time zone.</returns>
    public DateTime GetTimeZoneTime(string? id)
    {
        if (string.IsNullOrEmpty(id))
            return DateTime.Now;

        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(id);
        if (timeZone is null) return DateTime.UtcNow;

        var currentTime = DateTime.UtcNow;
        var localTime = TimeZoneInfo.ConvertTimeFromUtc(currentTime, timeZone);
        return localTime;

    }

    /// <summary>
    /// Retrieves a collection of all time zones defined on the system.
    /// </summary>
    /// <remarks>This method provides access to the system's time zone information, which can be useful for
    /// applications that need to handle date and time across different regions.</remarks>
    /// <returns>An enumerable collection of <see cref="TimeZoneInfo"/> objects representing the time zones available on the
    /// system.</returns>
    public IEnumerable<TimeZoneInfo> GetTimeZones()
        => TimeZoneInfo.GetSystemTimeZones();
}
