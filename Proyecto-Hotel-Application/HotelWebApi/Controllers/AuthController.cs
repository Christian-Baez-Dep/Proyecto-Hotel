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
        private readonly RegistryUsers _registryUsers;


        public AuthController(AuthUsers authUsers, RegistryUsers registryUsers)
        {
            _authUsers = authUsers;
            _registryUsers = registryUsers;
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

        [HttpPost("Register")]
        public async Task<IActionResult> Registro([FromBody] RegistroRequest request)
        {
            try
            {
                ResponseClient response = await _registryUsers.RegistrarUsuario
                    (request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "No se puedo completar el registro. Error." + ex.Message });
            }






        }
    }
}
