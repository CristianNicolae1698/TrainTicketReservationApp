using BookTrainTickets.DataAccess;
using BookTrainTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrainTickets.Methods
{
    public class CreateRoute2
    {
        private static List<Train> CreateTrains()
        {
            var trains = new List<Train>();
            var t1 = new Train
            {

                TrainNumber = "424",
                TrainType = "CommonRail"
            };
            var t2 = new Train
            {

                TrainNumber = "525",
                TrainType = "LightRail"
            };
            var t3 = new Train
            {

                TrainNumber = "626",
                TrainType = "MagLev"
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
                StationName = "Brasov"
            };
            var st2 = new Station
            {
                StationName = "Constanta"
            };

            stations.Add(st1);
            stations.Add(st2);

            return stations;
        }


        public static void CreateRoute()
        {



            var route2 = new Route
            {
                RouteName = "Brasov - Constanta",



            };


            route2.Trains.AddRange(CreateTrains());
            route2.Stations.AddRange(CreateStations());
            using (var db = new BookingContext())
            {
                db.Routes.Add(route2);

                db.SaveChanges();
            }


        }
    }
}
