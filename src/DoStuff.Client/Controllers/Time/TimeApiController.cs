using Asp.Versioning;

using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Collections;

namespace DoStuff.Client.Controllers.Time;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Time")]
public class TimeApiController : DoStuffClientApiControllerBase
{
    private readonly ITimeService _timeService;

    public TimeApiController(ITimeService timeService)
    {
        _timeService = timeService;
    }

    /// <summary>
    ///  Fetches the current date and time from the server. 
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetCurrentTime")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public IActionResult GetCurrentTime()
        => Ok(_timeService.GetCurrentTime().ToString("HH:mm:ss"));

    [HttpGet("GetCurrentDate")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public IActionResult GetCurrentDate()
        => Ok(_timeService.GetCurrentTime().ToShortDateString());

    [HttpGet("GetTimezoneTime")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public IActionResult GetTimezoneTime(string timezone)
        => Ok(_timeService.GetTimeZoneTime(timezone).ToString("HH:mm:ss"));

    [HttpGet("GetTimeZones")]
    [ProducesResponseType<IEnumerable<TimeZoneInfo>>(StatusCodes.Status200OK)]
    public IActionResult GetTimeZones()
        => Ok(_timeService.GetTimeZones());

    [HttpPost("GetTimeZoneTimes")]
    [ProducesResponseType<IEnumerable<TimeZoneDisplayTime>>(StatusCodes.Status200OK)]
    public IActionResult GetTimeZoneTimes(IEnumerable<TimeZoneSetting> timezones)
    {
        var result = timezones.Select(tz => new TimeZoneDisplayTime
        {
            Id = tz.Id,
            Name = tz.Name,
            Value = _timeService.GetTimeZoneTime(tz.Id).ToString("HH:mm:ss")
        });

        return Ok(result);
    }
}