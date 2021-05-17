using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StartWithAPI.DTO;
using StartWithAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI.Services
{
    public class AppUserService : IAppUserService
    {
        private IAppUserRepo _repo;
        private IMapper _mapper;

        public AppUserService(IAppUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _repo.ToListAsync();
        }

        public async Task<AppUser> GetUserAsync(int id)
        {
            return await _repo.FindAsync(id);
        }

        public async Task AddUserAsync(AppUser user)
        {
            await _repo.AddAsync(user);
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(int id)
        {
            var user = new AppUser { Id = id };
            _repo.Attach(user);
            _repo.Update(user);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = new AppUser { Id = id };
            _repo.Attach(user);
            _repo.Remove(user);
            await _repo.SaveChangesAsync();
        }



        public async Task<MemberDTO> GetMemberAsync(int id)
        {
            AppUser user = await _repo.GetUserAsync(id);

            MemberDTO member = _mapper.Map<MemberDTO>(user);

            return member;
        }
    }
}
