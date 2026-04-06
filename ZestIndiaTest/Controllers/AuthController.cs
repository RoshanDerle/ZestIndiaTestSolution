using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZestIndiaTest.JwtServices;
using ZestIndiaTest.Models;

namespace ZestIndiaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwt;

        public AuthController(JwtService jwt)
        {
            _jwt = jwt;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "admin")
            {
                var token = _jwt.GenerateToken(model.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
