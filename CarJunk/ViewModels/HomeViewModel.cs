using CarJunk.Models;

namespace CarJunk.ViewModels
{
    public class HomeViewModel
    {
        public List<AutoReacondicionado> AutosDestacados { get; set; } = new();
        public List<AutoPiezas> AutosPiezas { get; set; } = new();
        public List<string> Marcas { get; set; } = new();
    }
}