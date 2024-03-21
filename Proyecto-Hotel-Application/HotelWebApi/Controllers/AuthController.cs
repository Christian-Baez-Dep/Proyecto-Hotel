using Business.Services;
using Entidades.Modelo;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HotelWebApi.Controllers;
using Entity.Entidades;

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
        public  IActionResult Login([FromBody]LoginRequest request)
        {
             ResponseClient response =  _authUsers.Authenticate(request.Email, request.Password);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(new {mensaje = "El usuario o contraseña son incorrectos." });
            }
        }
    }
}
