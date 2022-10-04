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
        public static void Initialize(BookingContext context)
        {
            context.Database.EnsureCreated();

            //Look for any routes
            if (context.Trains.Any() && context.Stations.Any() && context.Routes.Any())
            {
                return; //DB has been seeded
            }

            List<Train> trainList = new List<Train>()
            {
                new Train{Id=Guid.NewGuid(),TrainNumber="23456", TrainType="RapidBucuresti"},
                new Train{Id=Guid.NewGuid(),TrainNumber="987654321", TrainType="AcceleratulDeBuzau"}
            };
            
            foreach(var train1 in trainList)
            {
                context.Trains.Add(train1);
            }
            context.SaveChanges();

            List<Station> stationList = new List<Station>()
            {
                new Station{Id=Guid.NewGuid(),StationName="Bucuresti"},
                new Station{Id=Guid.NewGuid(),StationName="Craiova"},
                new Station{Id=Guid.NewGuid(),StationName="Sibiu"},
                new Station{Id=Guid.NewGuid(),StationName="Constanta"}

            };
            foreach(var station in stationList)
            {
                context.Stations.Add(station);
            }
            context.SaveChanges();
            var route = new Route
            { 
                RouteName = $"{stationList[0].StationName} - {stationList[1].StationName} - {trainList[0].TrainType}"
             };
            Station stationArrival = context.Stations.First(s => s.StationName == stationList[0].StationName);
            route.Stations.Add(stationArrival);
            Station stationDeparture = context.Stations.First(s => s.StationName == stationList[1].StationName);
            route.Stations.Add(stationDeparture);
            Train train = context.Trains.First(t => t.TrainType == trainList[0].TrainType);
            route.Trains.Add(train);
            context.Routes.Add(route);
            context.SaveChanges();


           

        }



    }
    
}
