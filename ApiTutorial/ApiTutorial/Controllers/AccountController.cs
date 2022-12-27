using ApiTutorial.Model;
using ApiTutorial.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IAccountRepository _accountRepository { get; }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody]Signup user)
        {
            var _user = await _accountRepository.SignUp(user);
            if (_user.Succeeded)
            {
                return Ok("Succeded");
            }
            return Unauthorized();
        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignIn user)
        {
            var _user = await _accountRepository.SignIn(user);
            if (String.IsNullOrEmpty(_user))
            {
                return Unauthorized();
            }
            return Ok(_user);
           
        }
    }
}
