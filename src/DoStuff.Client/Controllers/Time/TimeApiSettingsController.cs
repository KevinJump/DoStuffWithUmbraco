using Asp.Versioning;

using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Umbraco.Cms.Core.Security;

namespace DoStuff.Client.Controllers.Time;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "TimeSettings")]
public class TimeApiSettingsController : DoStuffClientApiControllerBase
{
    private readonly IBackOfficeSecurityAccessor _backOfficeSecurityAccessor;
    private readonly ITimeSettingsService _timeSettingsService;

    public TimeApiSettingsController(IBackOfficeSecurityAccessor backOfficeSecurityAccessor, ITimeSettingsService timeSettingsService)
    {
        _backOfficeSecurityAccessor = backOfficeSecurityAccessor;
        _timeSettingsService = timeSettingsService;
    }

    [HttpGet("GetTimeSettings")]
    [ProducesResponseType<TimeSettings>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetTimeSettings()
    {
        var user = _backOfficeSecurityAccessor.BackOfficeSecurity?.CurrentUser;
        if (user is null) return BadRequest("No user found");

        var settings = await _timeSettingsService.GetByUser(user.Key);
        return Ok(settings ?? new TimeSettings { UserKey = user.Key });
    }

    [HttpPost("SaveTimeSettings")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SaveTimeSettings(TimeSettings settings)
    {
        var user = _backOfficeSecurityAccessor.BackOfficeSecurity?.CurrentUser;
        if (user is null) return BadRequest("No user found");
        settings.UserKey = user.Key;
        
        await _timeSettingsService.SaveAsync(settings);
        return Ok();
    }
}
