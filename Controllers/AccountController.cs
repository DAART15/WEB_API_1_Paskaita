using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_1_Paskaita.Services;

namespace WEB_API_1_Paskaita.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IJwtService _jwtService;

        public AccountController(IAccountService accountService, IJwtService jwtService)
        {
            _accountService = accountService;
            _jwtService = jwtService;
        }
        [HttpPost("Register")]
        public ActionResult Register(string username, string password)
        {
            _accountService.Register(username, password);

            return Ok();
        }
        [HttpGet("Login")]
        public ActionResult Login(string username, string password)
        {

            if (_accountService.Login(username, password))
            {
                return Ok(_jwtService.GenerateToken(username));
            }
            return Unauthorized();
        }
    }
}
