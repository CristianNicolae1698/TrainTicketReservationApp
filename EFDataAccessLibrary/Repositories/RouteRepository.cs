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
        public IEnumerable<Route> GetRouteByName(string name)
        {
            
                return (IEnumerable<Route>)_context.Routes.First(r => r.RouteName == name);
            
        }
    }
}
