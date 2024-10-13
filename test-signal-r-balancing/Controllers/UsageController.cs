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
            if(counter > 7200.0)
            {
                return Ok("0%");
            }
            else
            {
                return Ok(((int)Math.Floor(100 * ( 1.0 - counter / 7200.0 ))).ToString() + "%");
            }
        }
    }
}
