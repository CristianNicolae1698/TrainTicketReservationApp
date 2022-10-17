using DomainLibrary.Entities;
using DomainLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Repositories
{
    public class TrainRepository: GenericRepository<Train>,ITrainRepository
    {
        public TrainRepository(BookingContext context): base(context)
        {

        }

        public IEnumerable<Train> GetTrainsByRouteName(string routeName)
        {
            if (_context.Routes.First(r => r.RouteName == routeName) != null)
            {
               
                return _context.Routes.Include(t=>t.Trains).First(r=>r.RouteName==routeName).Trains.ToList();
            }
            else
            {
                return null;
            }
        }

        public Train GetFirstTrainFromRouteName(string routeName)
        {
            if(_context.Routes.First(r => r.RouteName == routeName) != null)
            {
                return _context.Routes.Include(t=>t.Trains).First(r=>r.RouteName==routeName).Trains.First();
            }
            else
            {
                return null;
            }
        }


    }
}
