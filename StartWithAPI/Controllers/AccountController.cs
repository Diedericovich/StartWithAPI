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
    public class AccountController: ControllerBase
    {
        private IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

    }
}
