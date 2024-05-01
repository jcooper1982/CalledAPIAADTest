using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OpenTelemetry.Trace;

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

            _logger.LogInformation("Downstream API call worked");

            var activity = Activity.Current;

            try
            {
                throw new Exception("Test exception2");
            }
            // If an exception is thrown, catch it and set the activity status to "Ok".
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Ok);
                activity?.RecordException(ex);
            }

            return Ok(response);
        }
    }
}
