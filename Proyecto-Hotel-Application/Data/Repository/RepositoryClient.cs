using Data.Contexts;
using Data.Interface;
using Entidades.Modelo;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RepositoryClient : IRepositoryClient
    {
        private readonly ApplicationContext _context;

        public RepositoryClient(ApplicationContext context)
        {
           _context = context; 
        }
        public bool Delete(int id)
        {
            try
            {
                Client client = _context.Clients.Find(id);
                if (client == null)
                {
                    return false;
                }
                else
                {
                    var reservation = _context.Reservations.Where(r => r.IdClient == client.Id);
                    _context.Reservations.RemoveRange(reservation);

                    _context.Clients.Remove(client);
                    _context.SaveChanges();
                    return true;
                }
            }catch (Exception ex)
            {
                return false;
            }
        }

        public Client Get(int id)
        {
            try
            {
                return _context.Clients.Find(id);
            }catch (Exception ex)
            {
                return null;
            }
        }

        public List<Client> GetAll()
        {
            try
            {
                return _context.Clients.ToList();
            }catch (Exception ex)
            {
                return null;
            }
        }


        public Client GetClienteByEmailPassword(string email, string password)
        {
            try
            {
                return (Client)_context.Clients.Where(c => c.Email == email & c.Password == password);
            }catch(Exception ex)
            {
                return null;
            }
        }

        public bool Update(Client entity)
        {
            try
            {
                Client clienteCambiar = _context.Clients.Find(entity.Id);
                clienteCambiar.Email = entity.Email;
                clienteCambiar.Password = entity.Password;
                _context.Update(clienteCambiar);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
