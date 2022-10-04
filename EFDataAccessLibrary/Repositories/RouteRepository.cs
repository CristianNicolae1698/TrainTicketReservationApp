﻿using DomainLibrary.Interfaces;
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
        public IEnumerable<Route> GetRouteByName(string name)
        {
            
                return (IEnumerable<Route>)_context.Routes.First(r => r.RouteName == name);
            
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






    }
}
