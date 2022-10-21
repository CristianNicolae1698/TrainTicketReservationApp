using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainLibrary.Entities;

namespace DomainLibrary.Interfaces
{
    public interface IRouteRepository :IGenericRepository<Route>
    {
       
        Guid GetRouteId(string arrivalStationName, string departureStationName);
        Route GetRouteByName(string routeName);

        IEnumerable<Station> GetStationsByRouteName(string routeName);

        IEnumerable<Train> GetTrainsByRouteName(string routeName);

        

        public Guid GetCLientIdByName(string firstName, string lastName);

        public Booking AddClientToBooking(Client client);

        

        public Booking CreateBooking(Guid clientId, Guid trainId);

        public Booking AddClientAndTrainToBooking(Client client, Train train);


    }
}
