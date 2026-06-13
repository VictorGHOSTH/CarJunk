using Microsoft.AspNetCore.Mvc;

namespace CarJunk.Controllers.Admin
{
    public class DesperdiciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
