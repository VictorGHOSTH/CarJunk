using CarJunk.Data;
using CarJunk.Models;
using CarJunk.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarJunk.Services
{
    public class PiezaService : IPiezaService
    {
        private readonly AppDbContext _db;
        public PiezaService(AppDbContext db) => _db = db;

        public async Task<List<Pieza>> GetByAutoIdAsync(int autoPiezasId) =>
            await _db.Piezas
                .Where(p => p.AutoPiezasId == autoPiezasId)
                .ToListAsync();

        public async Task<Pieza?> GetByIdAsync(int id) =>
            await _db.Piezas.FindAsync(id);

        public async Task CrearAsync(Pieza pieza)
        {
            _db.Piezas.Add(pieza);
            await _db.SaveChangesAsync();
        }

        public async Task VenderAsync(int piezaId, int cantidad, decimal precioVenta)
        {
            var pieza = await _db.Piezas.FindAsync(piezaId);
            if (pieza == null || pieza.Stock < cantidad) return;

            pieza.Stock -= cantidad;

            _db.VentasPiezas.Add(new VentaPieza
            {
                PiezaId = piezaId,
                CantidadVendida = cantidad,
                PrecioVenta = precioVenta,
                FechaVenta = DateTime.Now
            });

            await _db.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var pieza = await _db.Piezas.FindAsync(id);
            if (pieza == null) return;
            _db.Piezas.Remove(pieza);
            await _db.SaveChangesAsync();
        }
    }
}