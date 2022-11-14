using DomainLibrary.Entities;

namespace TrainTicketsAppWebAPI.DTOs
{
    public class ClientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<BookingDto> Bookings { get; set; } = new List<BookingDto>();
    }
}
