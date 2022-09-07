using BookTrainTickets.DataAccess;
using BookTrainTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrainTickets.Methods
{
    public class TestNewRoute
    {
        
    public static List<Station> CreateStations()
        {
            List<Station> list = new List<Station>();
            list.Add(new Station { StationName = "Bucharest" });
            list.Add(new Station { StationName = "Sibiu" });
            list.Add(new Station { StationName = "Bacau" });

            

            return list;
        }



        public static List<Station> AddStationToList()
        {
            
            list.Add(new Station { StationName = "Bucharest" });
            list.Add(new Station { StationName = "Sibiu" });
            list.Add(new Station { StationName = "Bacau" });



            return list;
        }
        public static void CreateRoute4()
        {
            var route4 = new Route
            {
                RouteName = $"{CreateStations()[1].StationName} - {CreateStations()[2].StationName}"



            };

            route4.Stations.Add(CreateStations()[1]);
            route4.Stations.Add(CreateStations()[2]);
            using (var db = new BookingContext())
            {
                db.Routes.Add(route4);

                db.SaveChanges(); 
            }

        }

       


    }
}
