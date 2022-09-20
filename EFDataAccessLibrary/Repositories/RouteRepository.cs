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
        public IEnumerable<Route> GetPopularRoutes(int count)
        {
            return _context.Routes.OrderByDescending(d => d.StationOrder).Take(count).ToList();
        }
    }
}
