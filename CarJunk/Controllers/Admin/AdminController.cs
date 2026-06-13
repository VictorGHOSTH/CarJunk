using Microsoft.AspNetCore.Mvc;

namespace CarJunk.Controllers.Admin
{
    public class AdminController : Controller
    {
        public IActionResult Index() => Content("Admin próximamente");
    }
}