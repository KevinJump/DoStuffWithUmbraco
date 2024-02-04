using Asp.Versioning;

using Microsoft.AspNetCore.Mvc;

namespace DoStuff.Core.Controllers.Time;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "time")]
public class DoStuffTimeController : DoStuffControllerBase
{
    [HttpGet("time")]
    [ProducesResponseType(typeof(string), 200)]
    public string GetTime()
        => DateTime.Now.ToString("T");

    [HttpGet("date")]
    [ProducesResponseType(typeof(string), 200)]
    public string GetDate()
        => DateTime.Now.ToString("D");
}
