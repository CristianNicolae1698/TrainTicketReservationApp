using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BookTrainTickets.Models;

namespace BookTrainTickets.Data
{
    public class BookingContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Route> Routes{ get; set; }

        public DbSet<Station> Stations { get; set; }
        
        public DbSet<Train> Trains { get; set; }  
        
        

        


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();
            options.UseSqlServer(config.GetConnectionString("Default"));
        }
    }
}
