using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Auth;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<object> login([FromBody] LoginDto userLogin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (userLogin == null)  return BadRequest();

            var user = await _loginService.FindByEmail(userLogin.Email);
            if (user == null) return NotFound();
            
            return user;
        }
    }
}