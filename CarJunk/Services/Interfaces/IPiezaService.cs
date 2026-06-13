using CarJunk.Models;

namespace CarJunk.Services.Interfaces
{
    public interface IPiezaService
    {
        Task<List<Pieza>> GetByAutoIdAsync(int autoPiezasId);
        Task<Pieza?> GetByIdAsync(int id);
        Task CrearAsync(Pieza pieza);
        Task VenderAsync(int piezaId, int cantidad, decimal precioVenta);
        Task EliminarAsync(int id);
    }
}