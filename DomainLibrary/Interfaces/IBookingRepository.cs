using DomainLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Interfaces
{
    public interface IBookingRepository:IGenericRepository<Booking>
    {

        public void PostBooking(Guid clientId, Guid trainId, Guid routeId);

        public IEnumerable<Booking> DisplayBookingsByClientId(Guid clientId);

    }
}
