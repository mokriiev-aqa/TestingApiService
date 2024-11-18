using Microsoft.AspNetCore.Mvc;
using Testing_Api_Service.Repository;

namespace Testing_Api_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProphecyController : ControllerBase
    {
        private readonly ILogger<ProphecyController> _logger;

        public ProphecyController(ILogger<ProphecyController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProphecy")]
        public string Get([FromQuery] string topic)
        {
            var response = $"You prophecy about \"{topic}\" is: Some random text";

            var dbRepo = new TestRunsRepository();
            dbRepo.LogTestExecutionTime(topic, response);
            return response;
        }
    }
}
