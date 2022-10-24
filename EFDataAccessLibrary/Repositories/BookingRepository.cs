using DomainLibrary.Entities;
using DomainLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Repositories
{
    public class BookingRepository: GenericRepository<Booking>,IBookingRepository
    {
        public BookingRepository(BookingContext context) : base(context)
        {

        }


        public Booking CreateBooking(Guid clientId, Guid trainId)
        {
            var booking = new Booking();
            if (_context.Clients.First(c => c.Id == clientId) != null)
            {
                Client client = _context.Clients.First(c => c.Id == clientId);
                booking.Clients.Add(client);
            }
            if (_context.Trains.First(c => c.Id == trainId) != null)
            {
                Train train = _context.Trains.First(t => t.Id == trainId);
                booking.Trains.Add(train);
            }
            return booking;

        }

        public Booking AddClientToBooking(Client client)
        {
            var booking = new Booking();
            booking.Clients.Add(client);
            return booking;

        }

        public Booking AddClientAndTrainToBooking(Client client, Train train)
        {
            var booking = new Booking();
            booking.Trains.Add(train);
            booking.Clients.Add(client);
            return booking;

        }

    }
}
