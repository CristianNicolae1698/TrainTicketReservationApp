using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRouteRepository Routes { get; set; }
        IStationRepository Stations { get; set; }
        ITrainRepository Trains { get; set; }
        IClientRepository Clients { get; set; } 
        IBookingRepository Bookings { get; set; }    
        int Complete();
    }
}
