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

        public Guid GetCLientIdByName(string firstName, string lastName)
        {
            if (_context.Clients.First(c => c.FirstName == firstName && c.LastName == lastName) != null)
            {
                return _context.Clients.First(c => c.FirstName == firstName && c.LastName == lastName).Id;
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}
