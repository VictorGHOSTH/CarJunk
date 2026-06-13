using CarJunk.Models;

namespace CarJunk.ViewModels
{
    public class PiezasAutoViewModel
    {
        public AutoPiezas Auto { get; set; } = null!;
        public int Completitud { get; set; }
    }
}