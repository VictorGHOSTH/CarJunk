namespace CarJunk.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(string nombreUsuario, string password);
    }
}