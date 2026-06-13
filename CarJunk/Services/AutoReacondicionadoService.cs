using CarJunk.Data;
using CarJunk.Models;
using CarJunk.Models.Enums;
using CarJunk.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarJunk.Services
{
    public class AutoReacondicionadoService : IAutoReacondicionadoService
    {
        private readonly AppDbContext _db;
        public AutoReacondicionadoService(AppDbContext db) => _db = db;

        public async Task<List<AutoReacondicionado>> GetListosParaVentaAsync() =>
            await _db.AutosReacondicionados
                .Where(a => a.Estado == EstadoAuto.Listo)
                .OrderByDescending(a => a.FechaRegistro)
                .ToListAsync();

        public async Task<List<AutoReacondicionado>> GetTodosAsync() =>
            await _db.AutosReacondicionados
                .OrderByDescending(a => a.FechaRegistro)
                .ToListAsync();

        public async Task<AutoReacondicionado?> GetByIdAsync(int id) =>
            await _db.AutosReacondicionados.FindAsync(id);

        public async Task<List<string>> GetMarcasAsync() =>
            await _db.AutosReacondicionados
                .Where(a => a.Estado == EstadoAuto.Listo)
                .Select(a => a.Marca)
                .Distinct()
                .ToListAsync();

        public async Task<List<AutoReacondicionado>> FiltrarAsync(string? marca, int? year, decimal? min, decimal? max)
        {
            var query = _db.AutosReacondicionados
                .Where(a => a.Estado == EstadoAuto.Listo);

            if (!string.IsNullOrEmpty(marca))
                query = query.Where(a => a.Marca == marca);
            if (year.HasValue)
                query = query.Where(a => a.Year == year.Value);
            if (min.HasValue)
                query = query.Where(a => a.Precio >= min.Value);
            if (max.HasValue)
                query = query.Where(a => a.Precio <= max.Value);

            return await query.OrderByDescending(a => a.FechaRegistro).ToListAsync();
        }
    }
}