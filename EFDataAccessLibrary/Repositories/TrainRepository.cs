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
    }
}
