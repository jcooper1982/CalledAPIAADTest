using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalledAPIAADTest.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api2/downstream")]
    public class DownStreamAPIController : ControllerBase
    {
        private readonly ILogger<DownStreamAPIController> _logger;

        public DownStreamAPIController(ILogger<DownStreamAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetDownstreamResponse")]
        public IActionResult Get()
        {
            var response = new CalledAPIResponse
            {
                API2Response = "This is the downstream response"
            };

            return Ok(response);
        }
    }
}
