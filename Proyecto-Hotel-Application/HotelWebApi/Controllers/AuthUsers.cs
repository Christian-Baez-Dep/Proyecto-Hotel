using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Entidades.Modelo;
using Microsoft.EntityFrameworkCore;

//Roberto Sebastian Capellan Perez #2022-0950
namespace HotelWebApi.Controllers
{
    public class AuthUsers
    {
        private readonly ApplicationContext _context;

        public AuthUsers(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Client> AuthenticateAsync(string email, string password)
        {
            try
            {
                var client = await _context.Clients.FirstOrDefaultAsync(c => c.Email == email);

                if (client != null && client.Password == password)
                {
                    return client;
                }

                throw new Exception("Credenciales de usuario incorrectas");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al iniciar sesion {ex.Message}");
                return null;
            }
        }
    }
}