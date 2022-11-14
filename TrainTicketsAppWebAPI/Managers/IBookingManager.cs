using DomainLibrary.Interfaces;

namespace TrainTicketsAppWebAPI.Managers
{
    public interface IBookingManager :IDisposable
    {
        IBookingRepository Bookings { get; set; }
        int Complete();
    }
}
