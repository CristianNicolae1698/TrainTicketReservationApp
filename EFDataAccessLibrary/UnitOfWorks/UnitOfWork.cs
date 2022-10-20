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
            Trains=new TrainRepository(_context);
            Clients = new ClientRepository(_context);
            Bookings = new BookingRepository(_context);
        }
        public IRouteRepository Routes { get; set; }
        public IStationRepository Stations { get; set; }
        public IBookingRepository Bookings { get; set; }
        public IClientRepository Clients { get; set; }
        public ITrainRepository Trains { get; set; }




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
