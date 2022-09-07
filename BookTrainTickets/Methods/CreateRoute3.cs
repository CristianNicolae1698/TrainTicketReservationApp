using BookTrainTickets.DataAccess;
using BookTrainTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrainTickets.Methods
{
    public class CreateRoute3
    {
        private static List<Train> CreateTrains()
        {
            var trains = new List<Train>();
            var t1 = new Train
            {

                TrainNumber = "363",
                TrainType = "InterContinental"
            };
            var t2 = new Train
            {

                TrainNumber = "464",
                TrainType = "ModernRail"
            };
            var t3 = new Train
            {

                TrainNumber = "565",
                TrainType = "HighSpeedLev"
            };

            trains.Add(t1);
            trains.Add(t2);
            trains.Add(t3);
            return trains;

        }

        private static List<Station> CreateStations()
        {
            var stations = new List<Station>();
            var st1 = new Station
            {
                StationName = "Bucuresti"
            };
            var st2 = new Station
            {
                StationName = "Brasov"
            };

            stations.Add(st1);
            stations.Add(st2);

            return stations;
        }


        public static void CreateRoute()
        {



            var route3 = new Route
            {
                RouteName = $"{CreateStations()[0].StationName} - {CreateStations()[1].StationName}"



            };


            route3.Trains.AddRange(CreateTrains());
            route3.Stations.AddRange(CreateStations());
            using (var db = new BookingContext())
            {
                db.Routes.Add(route3);

                db.SaveChanges();
            }


        }
    }
}
