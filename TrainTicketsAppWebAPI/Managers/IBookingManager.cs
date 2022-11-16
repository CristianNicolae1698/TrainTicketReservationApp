using DomainLibrary.Entities;
using DomainLibrary.Interfaces;

namespace TrainTicketsAppWebAPI.Managers
{
    public interface IBookingManager 
    {
        IBookingRepository Bookings { get; set; }

        public IEnumerable<Booking> DisplayBookings(Guid clientId);

        public bool CreateBooking(Guid clientId, Guid trainId, Guid routeId);
    }
}
