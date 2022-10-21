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
                return _context.Routes.Include(s => s.Stations).First(r => r.RouteName == routeName).Stations.ToList();
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
                return _context.Routes.Include(t => t.Trains).First(r => r.RouteName == routeName).Trains.ToList();
            }
            else
            {
                return null;
            }

        }


        

        public Guid GetCLientIdByName(string firstName, string lastName)
        {
            if(_context.Clients.First(c => c.FirstName == firstName && c.LastName == lastName) != null)
            {
                return _context.Clients.First(c => c.FirstName == firstName && c.LastName == lastName).Id;
            }
            else
            {
                return Guid.Empty;
            }
        }

        public Booking AddClientToBooking(Client client)
        {
            var booking = new Booking();
            booking.Clients.Add(client);
            return booking;

        }

        public Booking AddClientAndTrainToBooking(Client client, Train train)
        {
            var booking = new Booking();
            booking.Trains.Add(train);
            booking.Clients.Add(client);
            return booking;

        }

        public Booking CreateBooking(Guid clientId, Guid trainId)
        {
            var booking = new Booking();
            if (_context.Clients.First(c => c.Id == clientId) != null)
            {
                Client client = _context.Clients.First(c => c.Id == clientId);
                booking.Clients.Add(client);
            }
            if (_context.Trains.First(c => c.Id == trainId) != null)
            {
                Train train = _context.Trains.First(t => t.Id == trainId);
                booking.Trains.Add(train);
            }
            return booking;

        }








        









    }
}
