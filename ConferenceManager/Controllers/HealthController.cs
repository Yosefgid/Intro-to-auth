using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("/health")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok("Ok lets go");
        }
    }
}
