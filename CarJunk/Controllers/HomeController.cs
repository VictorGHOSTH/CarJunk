using CarJunk.Models;
using CarJunk.Services.Interfaces;
using CarJunk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarJunk.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAutoReacondicionadoService _autosService;
        private readonly IAutoPiezasService _piezasService;

        public HomeController(IAutoReacondicionadoService autosService, IAutoPiezasService piezasService)
        {
            _autosService = autosService;
            _piezasService = piezasService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Active"] = "home";
            var vm = new HomeViewModel
            {
                AutosDestacados = await _autosService.GetListosParaVentaAsync(),
                AutosPiezas = await _piezasService.GetConPiezasDisponiblesAsync(),
                Marcas = await _autosService.GetMarcasAsync()
            };
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}