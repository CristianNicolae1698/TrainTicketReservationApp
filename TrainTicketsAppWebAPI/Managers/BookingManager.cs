using DomainLibrary.Interfaces;
using DomainLibrary.Entities;

namespace TrainTicketsAppWebAPI.Managers
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IBookingRepository Bookings { get; set; }

        public bool CreateBooking(Guid clientId, Guid trainId, Guid routeId)
        {
            try
            {
                _bookingRepository.PostBooking(clientId, trainId, routeId);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<Booking> DisplayBookings(Guid clientId)
        {
            return _bookingRepository.DisplayBookingsByClientId(clientId);
        }
        
    }
}
