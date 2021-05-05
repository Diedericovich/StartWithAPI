using Microsoft.AspNetCore.Mvc;
using StartWithAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
    {
        private AppUserService _service;

        public UsersController()
        {
            //TODO: Use Dependency Injection
            _service = new AppUserService();
        }

        [HttpGet]
        public IEnumerable<AppUser> Get()
        {
            return _service.GetUsers();
        }
        [HttpGet("{id}")]
        public AppUser GetUser(int id)
        {
            return _service.GetUser(id);
        }


        [HttpPost]
        public void AddUser(AppUser user)
        {
            _service.AddUser(user);
        }
    }
}
