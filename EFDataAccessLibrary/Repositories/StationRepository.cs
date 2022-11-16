using DomainLibrary.Entities;
using DomainLibrary.Interfaces;

namespace EFDataAccessLibrary.Repositories
{
    public class StationRepository: GenericRepository<Station>, IStationRepository
    {
        public StationRepository(BookingContext context): base(context)
        {

        }
        

        

        
    }
}
