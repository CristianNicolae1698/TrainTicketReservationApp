using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRouteRepository Routes { get; }
        IStationRepository Stations { get; }
        ITrainRepository Trains { get; }
        IClientRepository Clients { get; } 
        IBookingRepository Bookings { get; }    
        int Complete();
    }
}
