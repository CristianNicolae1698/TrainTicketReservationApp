using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookTrainTickets.Core.IConfiguration;
using BookTrainTickets.Core.IRepositories;
using BookTrainTickets.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace BookTrainTickets.Data
{
    public class UnitOfWork :IUnitOfWork, IDisposable
    {

        private readonly BookingContext _context;
        
        private readonly ILogger _logger;

        public IRouteRepository Routes { get; set; }

        public UnitOfWork( BookingContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Routes = new RouteRepository(_context, _logger);
        }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }


        //garbage collector ???

        public void Dispose()
        {
            _context.Dispose();
        }


        
    }
}
