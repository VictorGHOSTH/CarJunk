using CarJunk.Data;
using CarJunk.Models;
using CarJunk.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarJunk.Services
{
    public class DesperdicioService : IDesperdicioService
    {
        private readonly AppDbContext _db;
        public DesperdicioService(AppDbContext db) => _db = db;

        public async Task<List<Desperdicio>> GetTodosAsync() =>
            await _db.Desperdicios
                .Include(d => d.AutoPiezas)
                .OrderByDescending(d => d.FechaCierre)
                .ToListAsync();

        public async Task<Desperdicio?> GetByIdAsync(int id) =>
            await _db.Desperdicios
                .Include(d => d.AutoPiezas)
                .FirstOrDefaultAsync(d => d.Id == id);

        public async Task CrearAsync(int autoPiezasId, string? descripcion)
        {
            _db.Desperdicios.Add(new Desperdicio
            {
                AutoPiezasId = autoPiezasId,
                Descripcion = descripcion,
                FechaCierre = DateTime.Now
            });
            await _db.SaveChangesAsync();
        }
    }
}