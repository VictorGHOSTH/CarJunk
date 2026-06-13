using CarJunk.Models;

namespace CarJunk.Services.Interfaces
{
    public interface IAutoReacondicionadoService
    {
        Task<List<AutoReacondicionado>> GetListosParaVentaAsync();
        Task<List<AutoReacondicionado>> GetTodosAsync();
        Task<AutoReacondicionado?> GetByIdAsync(int id);
        Task<List<string>> GetMarcasAsync();
        Task<List<AutoReacondicionado>> FiltrarAsync(string? marca, int? year, decimal? min, decimal? max);
    }
}