using Microsoft.AspNetCore.Mvc;

namespace CarJunk.Controllers.Admin
{
    public class PiezasAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
