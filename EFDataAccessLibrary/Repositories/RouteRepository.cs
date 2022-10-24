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


        

        

        

       








        









    }
}
