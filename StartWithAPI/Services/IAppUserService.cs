using StartWithAPI.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartWithAPI.Services
{
    public interface IAppUserService
    {
        Task AddUserAsync(AppUser user);
        Task DeleteUserAsync(int id);
        Task<AppUser> GetUserAsync(int id);
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task UpdateUserAsync(int id);

        Task<MemberDTO> GetMemberAsync(int id);
    }
}