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
        IEnumerable<Route> GetPopularRoutes(int count);

    }
}
