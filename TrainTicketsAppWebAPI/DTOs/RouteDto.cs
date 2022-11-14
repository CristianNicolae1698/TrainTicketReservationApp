using DomainLibrary.Entities;

namespace TrainTicketsAppWebAPI.DTOs
{
    public class RouteDto
    {
        public string RouteName { get; set; }

        public List<StationDto> Stations { get; set; } = new List<StationDto>();
        public List<TrainDto> Trains { get; set; } = new List<TrainDto>();
    }



}
