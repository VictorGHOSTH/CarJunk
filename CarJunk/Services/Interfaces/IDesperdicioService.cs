using CarJunk.Models;

namespace CarJunk.Services.Interfaces
{
    public interface IDesperdicioService
    {
        Task<List<Desperdicio>> GetTodosAsync();
        Task<Desperdicio?> GetByIdAsync(int id);
        Task CrearAsync(int autoPiezasId, string? descripcion);
    }
}