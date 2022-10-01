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
        ClientRepository(BookingContext context) : base(context)
        {

        }
    }
}
