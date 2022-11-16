using DomainLibrary.Interfaces;
using EFDataAccessLibrary.Repositories;
using EFDataAccessLibrary;
using TrainTicketsAppWebAPI.DTOs;
using DomainLibrary.Entities;
using Microsoft.AspNetCore.Routing;

namespace TrainTicketsAppWebAPI.Managers
{
    public class RouteManager : IRouteManager
    {
        private readonly IRouteRepository _routeRepository;
        public RouteManager(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;

        }

        public IRouteRepository Routes { get; set; }

        

        public IEnumerable<Train> GetTrainsByRoute(string departureStation, string arrivalStation)
        {
            List<Train> trainList = new List<Train>();
            trainList = _routeRepository.GetTrainsByStationsName(departureStation, arrivalStation).ToList();
            return trainList;
        }

        public Guid GetRouteIdByStations(string departureStations, string arrivalStation)
        {
            return _routeRepository.GetRouteIdByStationsName(departureStations, arrivalStation);
        }



    }
}
