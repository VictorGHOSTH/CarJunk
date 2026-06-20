namespace CarJunk.ViewModels.Admin
{
    public class DashboardViewModel
    {
        public int TotalReacondicionados { get; set; }
        public int ReacondicionadosListos { get; set; }
        public int ReacondicionadosPreventa { get; set; }

        public int AutosVendidos { get; set; }

        public int PiezasDisponibles { get; set; }
        public int PiezasVendidas { get; set; }

        public decimal IngresosTotales { get; set; }

        public int AutosPiezasCompletos { get; set; }
        public int AutosPiezasParciales { get; set; }

        public int AutosEnDesperdicio { get; set; }

        public List<ActividadItem> ActividadReciente { get; set; } = new();
        public List<AlertaItem> Alertas { get; set; } = new();
    }

    public class ActividadItem
    {
        public string Texto { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; // venta | preventa | pieza | listo
        public DateTime Fecha { get; set; }
    }

    public class AlertaItem
    {
        public string Texto { get; set; } = string.Empty;
    }
}