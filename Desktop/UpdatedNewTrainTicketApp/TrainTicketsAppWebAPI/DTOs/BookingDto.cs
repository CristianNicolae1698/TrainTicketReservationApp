using DomainLibrary.Entities;

namespace TrainTicketsAppWebAPI.DTOs
{
    public class BookingDto
    {
        public RouteDto Route { get; set; }

        public TrainDto Train { get; set; }

        public DateTime BookingDate { get; set; }

        public int Price { get; set; }
    }
}
