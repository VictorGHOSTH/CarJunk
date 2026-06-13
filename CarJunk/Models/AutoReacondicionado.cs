using CarJunk.Models.Enums;

namespace CarJunk.Models
{
    public class AutoReacondicionado : Auto
    {
        public decimal Precio { get; set; }
        public string Motor { get; set; } = string.Empty;
        public int Kilometraje { get; set; }
        public string? Descripcion { get; set; }
        public EstadoAuto Estado { get; set; } = EstadoAuto.Registro;
    }
}