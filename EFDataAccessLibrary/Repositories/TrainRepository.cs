using DomainLibrary.Entities;
using DomainLibrary.Interfaces;

namespace EFDataAccessLibrary.Repositories
{
    public class TrainRepository: GenericRepository<Train>,ITrainRepository
    {
        public TrainRepository(BookingContext context): base(context)
        {

        }

        


    }
}
