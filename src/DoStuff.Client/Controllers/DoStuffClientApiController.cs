using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoStuff.Client.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "DoStuff.Client")]
    public class DoStuffClientApiController : DoStuffClientApiControllerBase
    {

        [HttpGet("ping")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public string Ping() => "Pong";
    }
}
