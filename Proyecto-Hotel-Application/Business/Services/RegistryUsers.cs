using Data.Interface;
using Entity.Entidades;
using Entidades.Modelo;
using System;
using System.Threading.Tasks;

namespace Business.Services
{
    public class RegistryUsers
    {
        private readonly IRepositoryClient _repositoryClient;

        public RegistryUsers(IRepositoryClient repositoryClient)
        {
            _repositoryClient = repositoryClient;
        }

        public async Task<ResponseClient> RegistrarUsuario(RegistroRequest request)
        {
            var existingUser = await _repositoryClient.GetClienteByEmail(request.Email);
            if (existingUser != null)
            {
                throw new Exception("El usuario ya está registrado con este correo electrónico");
            }

            var newUser = new Client
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DocumentId = request.DocumentationId
            };

            var createdUser = await _repositoryClient.CreateClient(newUser);

            return new ResponseClient(createdUser.Id, createdUser.FirstName, createdUser.LastName);
        }
    }
}
