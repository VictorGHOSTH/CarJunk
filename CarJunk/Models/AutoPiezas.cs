namespace CarJunk.Models
{
    public class AutoPiezas : Auto
    {
        public ICollection<Pieza> Piezas { get; set; } = new List<Pieza>();

        // Calculado, no almacenado en BD
        public int Completitud =>
            Piezas.Count == 0 ? 0 :
            (int)((Piezas.Count(p => p.Stock > 0) / (double)Piezas.Count) * 100);
    }
}