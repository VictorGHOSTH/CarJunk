using Microsoft.AspNetCore.Mvc;

namespace CarJunk.Controllers
{
    public class AutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
