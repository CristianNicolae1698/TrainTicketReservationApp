using DomainLibrary.Entities;
using DomainLibrary.Interfaces;
using System;
using System.Collections.Generic;
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
                return _context.Routes.First(r => r.RouteName == routeName).Trains;
            }
            else
            {
                return null;
            }
        }


    }
}
