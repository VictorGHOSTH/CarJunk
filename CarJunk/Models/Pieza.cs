namespace CarJunk.Models
{
    public class Pieza
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal? Precio { get; set; }

        // FK
        public int AutoPiezasId { get; set; }
        public AutoPiezas AutoPiezas { get; set; } = null!;
    }
}