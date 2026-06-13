namespace CarJunk.Models
{
    public abstract class Auto
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public string? FotoUrl { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}