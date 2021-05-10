using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StartWithAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI.Services
{
    public class AppUserService : IAppUserService
    {
        private AppContext _context;
        private IMapper _mapper;

        public AppUserService(AppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUserAsync(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(int id)
        {
            var user = new AppUser { Id = id };
            _context.Attach(user);
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = new AppUser { Id = id };
            _context.Attach(user);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<MemberDTO> GetMemberAsync(int id)
        {
            AppUser user = await this.GetUserAsync(id);

            MemberDTO member = _mapper.Map<MemberDTO>(user);

            return member;
        }
    }
}
