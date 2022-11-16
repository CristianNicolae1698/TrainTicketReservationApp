using DomainLibrary.Entities;
using DomainLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Repositories
{
    public class ClientRepository:GenericRepository<Client>,IClientRepository
    {
        public ClientRepository(BookingContext context) : base(context)
        {

        }

        public void PostClientIfNotExist(Client client)
        {
            
            if(_context.Clients.Any(c=>c.FirstName==client.FirstName && c.LastName == client.LastName))
            {
                throw new Exception("Client Already Exists");
            }
            else
            {
                _context.Clients.Add(client);
                
            }
        } 

       

        public Guid GetCLientIdByNameDto(Client client)
        {
            
            return _context.Clients.First(c => c.FirstName == client.FirstName && c.LastName == client.LastName).Id;
            
        }


        
    }
}
