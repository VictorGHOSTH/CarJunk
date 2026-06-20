using CarJunk.ViewModels.Admin;

namespace CarJunk.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboardDataAsync();
    }
}