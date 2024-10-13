using Microsoft.AspNetCore.Mvc;

namespace TestSignalRBalancing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsageController(CounterService counterService) : Controller
    {
        private CounterService counterService_ = counterService;

        [HttpGet]
        public IActionResult GetUsage()
        {
            int counter = counterService_.Counter;
            if(counter > 7200.0)
            {
                return Ok(0);
            }
            else
            {
                return Ok(Math.Floor(255 * ( 1.0 - counter / 7200.0 )));
            }
        }
    }
}
