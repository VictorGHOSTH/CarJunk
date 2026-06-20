using CarJunk.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarJunk.Controllers.Admin
{
    [Authorize]
    [Route("Admin/Reacondicionados")]
    public class ReacondicionadosController : Controller
    {
        private readonly IAutoReacondicionadoService _service;
        public ReacondicionadosController(IAutoReacondicionadoService service) => _service = service;

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index(string? estado)
        {
            ViewData["Active"] = "reacondicionados";
            ViewData["Title"] = "Autos Reacondicionados";
            var autos = await _service.GetTodosAsync();
            return View(autos);
        }

        [HttpGet("Crear")]
        public IActionResult Crear()
        {
            ViewData["Active"] = "reacondicionados";
            ViewData["Title"] = "Agregar Auto Reacondicionado";
            return View();
        }
    }
}