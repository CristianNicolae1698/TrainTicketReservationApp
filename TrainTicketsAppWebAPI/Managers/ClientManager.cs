using DomainLibrary.Interfaces;
using EFDataAccessLibrary.Repositories;
using EFDataAccessLibrary;

namespace TrainTicketsAppWebAPI.Managers
{
    public class ClientManager: IClientManager
    {
        private readonly BookingContext _context;
        public ClientManager(BookingContext context)
        {
            _context = context;
            Clients = new ClientRepository(_context);
            
        }
        
        public IClientRepository Clients { get; set; }
        

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
