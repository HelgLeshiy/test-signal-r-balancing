using Microsoft.AspNetCore.Mvc;

namespace TestSignalRBalancing.Controllers
{
    [ApiController]
    [Route("/")]
    public class UsageController(CounterService counterService) : Controller
    {
        private CounterService counterService_ = counterService;

        [HttpGet]
        public IActionResult GetUsage()
        {
            int counter = counterService_.Counter;
            string metric;
            if(counter > 7200.0)
            {
                metric = "up 0%\n";
            }
            else
            {
                metric = "up " + ((int)Math.Floor(100 * (1.0 - counter / 7200.0))).ToString() + "%\n";
            }

            Console.WriteLine($"Get Usage from {Environment.GetEnvironmentVariable("SERVER_NAME")}: {metric}");
            return Ok(metric);
        }
    }
}
