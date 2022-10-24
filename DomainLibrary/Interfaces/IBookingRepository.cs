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
        public Booking CreateBooking(Guid clientId, Guid trainId);

        public Booking AddClientToBooking(Client client);

        public Booking AddClientAndTrainToBooking(Client client, Train train);
    }
}
