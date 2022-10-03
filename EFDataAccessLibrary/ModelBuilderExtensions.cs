using DomainLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Station> stationsList;
            stationsList = new List<Station>
            {
                new Station{ Id = Guid.NewGuid(), StationName ="Bucuresti"},
                new Station{ Id = Guid.NewGuid(),StationName ="Craiova"}
            };
            modelBuilder.Entity<Route>().HasData( 
                new Route
                {
                RouteName = "Bucuresti-Craiova",
                Id = Guid.NewGuid(),
                StationOrder = 2,
                Stations = new List<Station> { stationsList[0], stationsList[1] }
                });


        }

    }
}
