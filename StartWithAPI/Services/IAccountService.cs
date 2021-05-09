using System.Threading.Tasks;

namespace StartWithAPI.Services
{
    public interface IAccountService
    {
        Task<AppUser> RegisterAsync(string userName, string password);
        Task<bool> UserExists(string name);
        Task<AppUser> LoginAsync(string name, string password);
    }
}