using DomainLibrary.Entities;
using DomainLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Repositories
{
    public class StationRepository: GenericRepository<Station>, IStationRepository
    {
        public StationRepository(BookingContext context): base(context)
        {

        }
    }
}
