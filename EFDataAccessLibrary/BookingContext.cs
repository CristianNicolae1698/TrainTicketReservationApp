
using DomainLibrary.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;

namespace EFDataAccessLibrary
{
    public class BookingContext : IdentityDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Booking> Bookings { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Client> Clients { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Route> Routes { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Station> Stations { get; set; }
        
        public Microsoft.EntityFrameworkCore.DbSet<Train> Trains { get; set; }



        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
           
        }



    }
}
