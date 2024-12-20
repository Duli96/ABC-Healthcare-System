using System.Threading.Tasks;

namespace AuthService.Services
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(string email, string password);
    }
}
