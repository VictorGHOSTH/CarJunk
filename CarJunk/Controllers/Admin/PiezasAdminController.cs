using CarJunk.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarJunk.Controllers.Admin
{
    [Authorize]
    [Route("Admin/PiezasAdmin")]
    public class PiezasAdminController : Controller
    {
        private readonly IAutoPiezasService _autoPiezasService;
        private readonly IPiezaService _piezaService;

        public PiezasAdminController(IAutoPiezasService autoPiezasService, IPiezaService piezaService)
        {
            _autoPiezasService = autoPiezasService;
            _piezaService = piezaService;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewData["Active"] = "autospiezas";
            ViewData["Title"] = "Autos para Piezas";
            var autos = await _autoPiezasService.GetTodosAsync();
            return View(autos);
        }

        [HttpGet("Crear")]
        public IActionResult Crear()
        {
            ViewData["Active"] = "autospiezas";
            ViewData["Title"] = "Agregar Auto para Piezas";
            return View();
        }

        [HttpGet("Inventario")]
        public async Task<IActionResult> Inventario()
        {
            ViewData["Active"] = "inventario";
            ViewData["Title"] = "Inventario de Piezas";
            var autos = await _autoPiezasService.GetTodosAsync();
            return View(autos);
        }

        [HttpGet("RegistrarPieza")]
        public IActionResult RegistrarPieza()
        {
            ViewData["Active"] = "inventario";
            ViewData["Title"] = "Registrar Pieza";
            return View();
        }
    }
}