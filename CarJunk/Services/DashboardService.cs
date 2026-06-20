using CarJunk.Data;
using CarJunk.Models.Enums;
using CarJunk.Services.Interfaces;
using CarJunk.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;

namespace CarJunk.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _db;
        public DashboardService(AppDbContext db) => _db = db;

        public async Task<DashboardViewModel> GetDashboardDataAsync()
        {
            var reacondicionados = await _db.AutosReacondicionados.ToListAsync();
            var autosPiezas = await _db.AutosPiezas.Include(a => a.Piezas).ToListAsync();
            var piezas = await _db.Piezas.ToListAsync();
            var ventas = await _db.VentasPiezas.ToListAsync();
            var desperdicios = await _db.Desperdicios.ToListAsync();

            var vm = new DashboardViewModel
            {
                TotalReacondicionados = reacondicionados.Count,
                ReacondicionadosListos = reacondicionados.Count(a => a.Estado == EstadoAuto.Listo),
                ReacondicionadosPreventa = reacondicionados.Count(a => a.Estado == EstadoAuto.Preventa),
                AutosVendidos = reacondicionados.Count(a => a.Estado == EstadoAuto.Vendido),

                PiezasDisponibles = piezas.Count(p => p.Stock > 0),
                PiezasVendidas = ventas.Sum(v => v.CantidadVendida),

                IngresosTotales = ventas.Sum(v => v.PrecioVenta * v.CantidadVendida),

                AutosPiezasCompletos = autosPiezas.Count(a => a.Completitud == 100),
                AutosPiezasParciales = autosPiezas.Count(a => a.Completitud < 100),

                AutosEnDesperdicio = desperdicios.Count
            };

            // Alertas automáticas
            var preventaVieja = reacondicionados
                .Where(a => a.Estado == EstadoAuto.Preventa && (DateTime.Now - a.FechaRegistro).TotalDays > 30)
                .Count();
            if (preventaVieja > 0)
                vm.Alertas.Add(new AlertaItem { Texto = $"{preventaVieja} auto(s) en preventa por más de 30 días" });

            var casiCompletos = autosPiezas.Where(a => a.Completitud >= 90 && a.Completitud < 100).Count();
            if (casiCompletos > 0)
                vm.Alertas.Add(new AlertaItem { Texto = $"{casiCompletos} auto(s) para piezas casi completo(s) (90%+)" });

            return vm;
        }
    }
}