using DomainLibrary.Interfaces;
using EFDataAccessLibrary.Repositories;
using EFDataAccessLibrary;

namespace TrainTicketsAppWebAPI.Managers
{
    public class RouteManager : IRouteManager
    {
        private readonly BookingContext _context;
        public RouteManager(BookingContext context)
        {
            _context = context;
            Routes = new RouteRepository(_context);

        }

        public IRouteRepository Routes { get; set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
