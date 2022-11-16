using DomainLibrary.Interfaces;
using DomainLibrary.Entities;

namespace EFDataAccessLibrary.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(BookingContext context) : base(context)
        {
        }
       
       

        //to be tested

        public IEnumerable<Train> GetTrainsByStations(Station departureStation, Station arrivalStation)
        {
            Route route = new Route();
            route = _context.Routes.Where(r => r.Stations.Contains(arrivalStation) && r.Stations.Contains(departureStation)).First();
            return _context.Trains.Where(r => r.Routes.Contains(route)).ToList();


        }

        public IEnumerable<Train> GetTrainsByStationsName(string departureStation, string arrivalStation)
        {
            Route route = new Route();
            Station DepartureStation=new Station();
            Station ArrivalStation = new Station();

            DepartureStation=_context.Stations.Where(s => s.StationName == departureStation).First();
            ArrivalStation = _context.Stations.Where(s => s.StationName == arrivalStation).First();

            route = _context.Routes.Where(r => r.Stations.Contains(ArrivalStation) && r.Stations.Contains(DepartureStation)).First();
            return _context.Trains.Where(r => r.Routes.Contains(route)).ToList();


        }

        public Guid GetRouteIdByStationsName(string departureStation, string arrivalStation)
        {
            Route route = new Route();
            Station DepartureStation = new Station();
            Station ArrivalStation = new Station();

            DepartureStation = _context.Stations.Where(s => s.StationName == departureStation).First();
            ArrivalStation = _context.Stations.Where(s => s.StationName == arrivalStation).First();

            route = _context.Routes.Where(r => r.Stations.Contains(ArrivalStation) && r.Stations.Contains(DepartureStation)).First();
            return route.Id;
        }


































    }
}
