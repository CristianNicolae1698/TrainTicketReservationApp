using DomainLibrary.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Migrations
{
    public static class BookingDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BookingContext>();
                context.Database.EnsureCreated();
                var train1 = new Train { Id = Guid.NewGuid(), TrainNumber = "123442q4433233", TrainType = "RapidBucuresti" };
                var train2 = new Train { Id = Guid.NewGuid(), TrainNumber = "9763662", TrainType = "InterCity" };

                var route1 = new Route { Id = Guid.NewGuid(), RouteName = "Bucuresti-Craiova" };
                route1.Trains.Add(train1);
                route1.Trains.Add(train2);
                context.SaveChanges();
            }
        }

        
    }
}
