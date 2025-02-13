using ECommerce.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (await _loginService.ValidateUserAsync(loginRequest.UserName, loginRequest.Password))
            {
                var token = _loginService.GenerateJwtToken(loginRequest.UserName);
                return Ok(new { Token = token });
            }

            return Unauthorized("Geçersiz kullanıcı adı veya şifre.");
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
