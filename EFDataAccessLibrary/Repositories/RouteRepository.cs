using DomainLibrary.Interfaces;
using DomainLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFDataAccessLibrary.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(BookingContext context) : base(context)
        {
        }
       

        public Guid GetRouteId(string arrivalStationName, string departureStationName)
        {
            Station arrivalStation=new Station();
            foreach(var station in _context.Stations)
            {
                if (arrivalStationName == station.StationName)
                {
                    arrivalStation = station;
                }
            }

            Station departureStation = new Station();
            foreach (var station in _context.Stations)
            {
                if (departureStationName == station.StationName)
                {
                    departureStation = station;
                }
            }


            foreach(var route in _context.Routes)
            {
                if (route.Stations.Contains(arrivalStation) && route.Stations.Contains(departureStation)){
                    return route.Id;
                }
            }
            return Guid.Empty;

        }

        public Route GetRouteByName(string routeName)
        {
            if(_context.Routes.First(r => r.RouteName == routeName)!=null)
            {
                return _context.Routes.Include(s => s.Stations).Include(t=>t.Trains).First();
            }
            else
            {
                return null;
            }

        }
        public IEnumerable<Station> GetStationsByRouteName(string routeName)
        {
            if (_context.Routes.First(r => r.RouteName == routeName) != null)
            {
                return _context.Routes.Include(s => s.Stations).First().Stations.ToList();
            }
            else
            {
                return null;
            }

        }

        public IEnumerable<Train> GetTrainsByRouteName(string routeName)
        {
            if (_context.Routes.First(r => r.RouteName == routeName) != null)
            {
                return _context.Routes.Include(t => t.Trains).First().Trains.ToList();
            }
            else
            {
                return null;
            }

        }










    }
}
