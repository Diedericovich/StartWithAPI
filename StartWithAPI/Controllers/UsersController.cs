using Microsoft.AspNetCore.Mvc;
using StartWithAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        private IAppUserService _service;

        public UsersController(IAppUserService service)
        {
            //TODO: Use Dependency Injection
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _service.GetUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<AppUser> GetUserAsync(int id)
        {
            return await _service.GetUserAsync(id);
        }


        [HttpPost]
        public async Task AddUserAsync(AppUser user)
        {
            await _service.AddUserAsync(user);
        }

        [HttpPut("{id}")]
        public async Task UpdateUserAsync(int id)
        {
            await _service.UpdateUserAsync(id);
        }

        [HttpDelete("{Id}")]
        public async Task DeleteUserAsync(int id)
        {
            await _service.DeleteUserAsync(id);
        }

    }
}
