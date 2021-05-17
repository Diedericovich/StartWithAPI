using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartWithAPI.Repositories
{
    public interface IAppUserRepo
    {
        Task AddUserAsync(AppUser user);
        Task DeleteUserAsync(int id);
        Task<AppUser> GetUserAsync(int id);
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task UpdateUserAsync(int id);
    }
}