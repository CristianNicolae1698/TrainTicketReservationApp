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
    public static class TestNewRoute
    {
        static List<Station> list = new List<Station>();

        public static List<Station> CreateStations()
        {

            list.Add(new Station { StationName = "Sibiu" });
            list.Add(new Station { StationName = "Bucharest" });
           
            return list;
        }



        public static List<Station> AddStationToList()
        {

            list.Add(new Station { StationName = "Bacau" });

            return list;
        }
        public static void CreateRoute4()
        {
            var route4 = new Route
            {
                RouteName = $"{list[0].StationName} - {list[1].StationName}"



            };

            route4.Stations.Add(list[0]);
            route4.Stations.Add(list[1]);
            
            var route5 = new Route
            {
                RouteName = $"{list[1].StationName} - {list[2].StationName}"



            };
            using (var db = new BookingContext())
            {
                db.Routes.Add(route4);

                db.SaveChanges();
            }
            

        }
        public static void CreateRoute5()
        {
            
            
            
            
            using (var db = new BookingContext())
            {
                var route5 = new Route
                {
                    RouteName = $"{list[1].StationName} - {list[2].StationName}"



                };

                Station station1 = db.Stations.FirstOrDefault(s => s.StationName == "Bucharest");
                route5.Stations.Add(station1);
                route5.Stations.Add(list[2]);
                db.Routes.Add(route5);

                db.SaveChanges();
            }

        }




    }
}
