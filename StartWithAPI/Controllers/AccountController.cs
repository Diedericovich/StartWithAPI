using Microsoft.AspNetCore.Mvc;
using StartWithAPI.DTO;
using StartWithAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {
        private IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }


        [HttpPost("Register")]

        public async Task<ActionResult<AppUser>> RegisterAsync(RegisterDTO dto)
        {
            if (await _service.UserExists(dto.Name))
            {
                return BadRequest("Username already exists");
            }

            var user = await _service.RegisterAsync(dto.Name, dto.Password);
            return user;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AppUser>> LoginAsync(LoginDTO dto)
        {
            try
            {
                AppUser user = await _service.LoginAsync(dto.Name, dto.Password);
                return user;
            }
            catch (UnauthorizedAccessException e)
            {

                return Unauthorized(e.Message);
            }

        }


        
    }
}
