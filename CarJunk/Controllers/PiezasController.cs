using Microsoft.AspNetCore.Mvc;

namespace CarJunk.Controllers
{
    public class PiezasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
