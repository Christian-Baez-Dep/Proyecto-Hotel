using Data.Contexts;
using System;
using Data.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Entidades.Modelo;
using Microsoft.EntityFrameworkCore;
using Entity.Entidades;

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

        public ResponseClient Authenticate(string email, string password)
        {
            var client = _repositoryClient.GetClienteByEmailPassword(email, password);

            if (client != null)
            {
                return new ResponseClient(client.Id, client.FirstName, client.LastName);

            }
            else
            {
                return null;
            }
        }
    }
}