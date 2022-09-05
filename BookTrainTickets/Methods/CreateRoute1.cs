using BookTrainTickets.DataAccess;
using BookTrainTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrainTickets.Methods
{
    public class CreateRoute1
    {
        private static List<Train> CreateTrains()
        {
            var trains = new List<Train>();
            var t1 = new Train
            {

                TrainNumber = "727",
                TrainType = "InterRegio"
            };
            var t2 = new Train
            {

                TrainNumber = "828",
                TrainType = "InterCity"
            };
            var t3 = new Train
            {

                TrainNumber = "929",
                TrainType = "InterEuropean"
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
                StationName = "Bucharest"
            };
            var st2 = new Station
            {
                StationName = "Craiova"
            };

            stations.Add(st1);
            stations.Add(st2);

            return stations;
        }


        public static void CreateRoute()
        {



            var route1 = new Route
            {
                RouteName = "Craiova - Bucharest",



            };


            route1.Trains.AddRange(CreateTrains());
            route1.Stations.AddRange(CreateStations());
            using (var db = new BookingContext())
            {
                db.Routes.Add(route1);

                db.SaveChanges();
            }


        }
    }
}
