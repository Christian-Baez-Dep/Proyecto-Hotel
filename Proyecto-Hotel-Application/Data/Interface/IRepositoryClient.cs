using Entidades.Modelo;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IRepositoryClient : IRepository<Client>
    {        
        public Client GetClienteByEmailPassword(string email, string password);
        public Task<Client> GetClienteByEmail(string email);
        public Task<Client> CreateClient(Client client);
    }
}
