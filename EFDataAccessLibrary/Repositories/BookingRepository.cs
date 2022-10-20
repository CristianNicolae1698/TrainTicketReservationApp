using DomainLibrary.Entities;
using DomainLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Repositories
{
    public class BookingRepository: GenericRepository<Booking>,IBookingRepository
    {
        public BookingRepository(BookingContext context) : base(context)
        {

        }

    }
}
