namespace CarJunk.Models
{
    public class VentaPieza
    {
        public int Id { get; set; }
        public int PiezaId { get; set; }
        public Pieza Pieza { get; set; } = null!;
        public int CantidadVendida { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public decimal PrecioVenta { get; set; }
    }
}