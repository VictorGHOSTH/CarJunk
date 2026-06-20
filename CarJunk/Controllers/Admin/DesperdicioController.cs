using CarJunk.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarJunk.Controllers.Admin
{
    [Authorize]
    [Route("Admin/Desperdicio")]
    public class DesperdicioController : Controller
    {
        private readonly IDesperdicioService _service;
        public DesperdicioController(IDesperdicioService service) => _service = service;

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewData["Active"] = "desperdicio";
            ViewData["Title"] = "Desperdicio";
            var desperdicios = await _service.GetTodosAsync();
            return View(desperdicios);
        }
    }
}