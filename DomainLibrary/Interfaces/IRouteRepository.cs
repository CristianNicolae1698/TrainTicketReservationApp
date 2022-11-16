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
       

        
        public IEnumerable<Train> GetTrainsByStations(Station departureStation, Station arrivalStation);

        public IEnumerable<Train> GetTrainsByStationsName(string departureStation, string arrivalStation);

        public Guid GetRouteIdByStationsName(string departureStation, string arrivalStation);




    }
}
