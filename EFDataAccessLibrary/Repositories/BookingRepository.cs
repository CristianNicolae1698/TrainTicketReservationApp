using DomainLibrary.Entities;
using Microsoft.EntityFrameworkCore;

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


        public Booking PostBooking(Guid clientId, Guid trainId, Guid routeId)
        {
            var booking = new Booking();
            
            booking.Train = _context.Trains.First(t => t.Id == trainId);
            booking.Route = _context.Routes.First(r => r.Id == routeId);
            _context.Clients.First(c => c.Id == clientId).Bookings.Add(booking);
            Random rd = new Random();
            booking.Price = rd.Next(100, 200);
            booking.BookingDate = DateTime.UtcNow;
            
            return booking;

        }
        

        public IEnumerable<Booking> DisplayBookingsByClientId(Guid clientId)
        {
            return _context.Bookings.Include(t => t.Train).Include(r => r.Route).Where(c => c.Client.Id == clientId).ToList();
            
        }

        

    }
}
