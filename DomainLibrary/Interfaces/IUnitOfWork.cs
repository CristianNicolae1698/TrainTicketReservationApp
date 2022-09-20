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

        int Complete();
    }
}
