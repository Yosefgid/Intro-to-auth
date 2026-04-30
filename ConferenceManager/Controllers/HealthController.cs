using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    public class HealthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
