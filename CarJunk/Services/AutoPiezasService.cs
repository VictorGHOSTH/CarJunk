using CarJunk.Data;
using CarJunk.Models;
using CarJunk.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarJunk.Services
{
    public class AutoPiezasService : IAutoPiezasService
    {
        private readonly AppDbContext _db;
        public AutoPiezasService(AppDbContext db) => _db = db;

        public async Task<List<AutoPiezas>> GetConPiezasDisponiblesAsync() =>
            await _db.AutosPiezas
                .Include(a => a.Piezas)
                .Where(a => a.Piezas.Any(p => p.Stock > 0))
                .OrderByDescending(a => a.FechaRegistro)
                .ToListAsync();

        public async Task<AutoPiezas?> GetByIdConPiezasAsync(int id) =>
            await _db.AutosPiezas
                .Include(a => a.Piezas)
                .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<List<AutoPiezas>> GetTodosAsync() =>
            await _db.AutosPiezas
                .Include(a => a.Piezas)
                .OrderByDescending(a => a.FechaRegistro)
                .ToListAsync();
    }
}