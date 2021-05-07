using System.Threading.Tasks;

namespace StartWithAPI.Services
{
    public interface IAccountService
    {
        Task<AppUser> RegisterAsync(string userName, string password);
    }
}