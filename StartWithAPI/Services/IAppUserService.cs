using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartWithAPI.Services
{
    public interface IAppUserService
    {
        Task AddUser(AppUser user);
        Task<AppUser> GetUser(int id);
        Task<List<AppUser>> GetUsers();
    }
}