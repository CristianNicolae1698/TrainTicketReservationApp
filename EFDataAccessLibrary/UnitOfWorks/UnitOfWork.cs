using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLibrary.Interfaces;
using EFDataAccessLibrary.Repositories;
using Microsoft.Extensions.Logging;

namespace EFDataAccessLibrary.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookingContext _context;
        public UnitOfWork(BookingContext context)
        {
            _context = context;
            Routes = new RouteRepository(_context);
            Stations = new StationRepository(_context);
        }
        public IRouteRepository Routes { get; private set; }
        public IStationRepository Stations { get; private set; }
        public IBookingRepository Bookings { get; private set; }
        public IClientRepository Clients { get; private set; }
        public ITrainRepository Trains { get; private set; }




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
