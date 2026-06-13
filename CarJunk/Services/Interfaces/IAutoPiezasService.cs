using CarJunk.Models;

namespace CarJunk.Services.Interfaces
{
    public interface IAutoPiezasService
    {
        Task<List<AutoPiezas>> GetConPiezasDisponiblesAsync();
        Task<AutoPiezas?> GetByIdConPiezasAsync(int id);
        Task<List<AutoPiezas>> GetTodosAsync();
    }
}