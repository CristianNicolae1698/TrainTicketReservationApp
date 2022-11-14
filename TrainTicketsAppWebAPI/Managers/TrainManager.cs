using DomainLibrary.Interfaces;
using EFDataAccessLibrary.Repositories;
using EFDataAccessLibrary;

namespace TrainTicketsAppWebAPI.Managers
{
    public class TrainManager : ITrainManager
    {
        private readonly BookingContext _context;
        public TrainManager(BookingContext context)
        {
            _context = context;
            Routes = new TrainRepository(_context);

        }

        public ITrainRepository Routes { get; set; }


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
