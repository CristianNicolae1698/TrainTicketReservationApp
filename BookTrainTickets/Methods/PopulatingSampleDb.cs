using BookTrainTickets.DataAccess;
using BookTrainTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookTrainTickets.Methods
{
    public static class PopulatingSampleDb
    {
        
        public static void AddTrainToDb(string trainName, string trainType)
        {
            using (var db = new BookingContext())
            {
                db.Trains.Add(new Train { TrainNumber = trainName, TrainType = trainType });
                db.SaveChanges();

            }
        }
        





        public static void AddStationToDb(string stationName)
        {

          
            using (var db = new BookingContext())
            {
                db.Stations.Add(new Station { StationName=stationName });
                db.SaveChanges();
            }
        }



        
        public static void AddRouteToDb(string departureStation, string arrivalStation,string trainNumber)
        {
                       
            
            using (var db = new BookingContext())
            {
                var route = new Route
                {
                    RouteName = $"{arrivalStation} - {departureStation} - { trainNumber }"
                };
                Station stationArrival = db.Stations.First(s => s.StationName == arrivalStation);
                route.Stations.Add(stationArrival);
                Station stationDeparture= db.Stations.First(s => s.StationName == departureStation);
                route.Stations.Add(stationDeparture);
                Train train=db.Trains.First(t => t.TrainType == trainNumber);
                route.Trains.Add(train);
                

                

                db.Routes.Add(route);

                db.SaveChanges();


            }

        }

        //to be implemented

        public static void MergeRoute()
        {


        }



    }
}
