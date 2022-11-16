using DomainLibrary.Entities;
using DomainLibrary.Interfaces;

namespace TrainTicketsAppWebAPI.Managers
{
    public interface IRouteManager 
    {
        IRouteRepository Routes { get; set; }

        public IEnumerable<Train> GetTrainsByRoute(string departureStation, string arrivalStation);

        public Guid GetRouteIdByStations(string departureStations, string arrivalStation);


    }
}