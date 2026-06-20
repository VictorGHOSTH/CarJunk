using CarJunk.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarJunk.Controllers.Admin
{
    [Authorize]
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IDashboardService _dashboardService;
        public AdminController(IDashboardService dashboardService) => _dashboardService = dashboardService;

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewData["Active"] = "dashboard";
            var vm = await _dashboardService.GetDashboardDataAsync();
            return View(vm);
        }

        [HttpGet("Configuracion")]
        public IActionResult Configuracion() => Content("Configuración próximamente");
    }
}