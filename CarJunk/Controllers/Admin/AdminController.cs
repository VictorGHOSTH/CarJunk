using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarJunk.Controllers.Admin
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index() => Content("Admin — sesión válida");
    }
}