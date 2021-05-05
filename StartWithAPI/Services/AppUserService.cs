using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI.Services
{
    public class AppUserService : IAppUserService
    {
        private AppContext _context;
        public AppUserService(AppContext context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetUsers()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task AddUser(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<AppUser> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
