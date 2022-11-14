using DomainLibrary.Interfaces;
using EFDataAccessLibrary.Repositories;
using EFDataAccessLibrary;

namespace TrainTicketsAppWebAPI.Managers
{
    public class BookingManager : IBookingManager
    {
        private readonly BookingContext _context;
        public BookingManager(BookingContext context)
        {
            _context = context;
            Bookings = new BookingRepository (_context);

        }

        public IBookingRepository Bookings { get; set; }


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
