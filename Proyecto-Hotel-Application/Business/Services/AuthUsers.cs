using Data.Contexts;
using System;
using Data.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Entidades.Modelo;
using Microsoft.EntityFrameworkCore;

//Roberto Sebastian Capellan Perez #2022-0950
namespace Business.Services
{
    public class AuthUsers 
    {
        private readonly IRepositoryClient _repositoryClient;

        public AuthUsers(IRepositoryClient repositoryClient)
        {
            _repositoryClient = repositoryClient;
        }

        public async Task<(bool,Client)> AuthenticateAsync(string email, string password)
        {
            var client = await _repositoryClient.GetClienteByEmailPassword(email, password);

            if (client != null)
            {
                return (true, client);
            }
            else
            {
                return (false, null);
            }
        }
    }
}