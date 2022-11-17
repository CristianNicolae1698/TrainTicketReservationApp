using DomainLibrary.Entities;
using DomainLibrary.Interfaces;

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
                _context.SaveChanges();
                
            }
        } 

       

        public Guid GetCLientIdByNameDto(Client client)
        {
            
            return _context.Clients.First(c => c.FirstName == client.FirstName && c.LastName == client.LastName).Id;
            
        }


        
    }
}
