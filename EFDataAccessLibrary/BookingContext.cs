
using DomainLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary
{
    public class BookingContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Route> Routes{ get; set; }

        public DbSet<Station> Stations { get; set; }
        
        public DbSet<Train> Trains { get; set; }

        

        public BookingContext(DbContextOptions<BookingContext> options) : base(options) { }
    }
}
