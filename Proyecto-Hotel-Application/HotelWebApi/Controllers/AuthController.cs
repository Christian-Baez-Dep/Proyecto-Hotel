using Business.Services;
using Entidades.Modelo;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HotelWebApi.Controllers;

namespace HotelWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthUsers _authUsers;

        public AuthController(AuthUsers authUsers)
        {
            _authUsers = authUsers;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var (success, client) = await _authUsers.AuthenticateAsync(request.Email, request.Password);

            if (success)
            {
                return Ok(client);
            }
            else
            {
                return Unauthorized(new {mensaje = "El usuario o contraseña son incorrectos." });
            }
        }
    }
}
