namespace CarJunk.Models
{
    public class Desperdicio
    {
        public int Id { get; set; }
        public int AutoPiezasId { get; set; }
        public AutoPiezas AutoPiezas { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaCierre { get; set; } = DateTime.Now;
    }
}