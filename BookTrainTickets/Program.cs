using BookTrainTickets.DataAccess;
using BookTrainTickets.Models;
using BookTrainTickets.Methods;
using System;
namespace BookTrainTickets
{
    public class Program
    {
        public static void Main(string[] args)

        {
            
            //PopulatingSampleDb.AddTrainToDb("EuroMaster", "525");
            //PopulatingSampleDb.AddTrainToDb("MagLev", "212");
            //PopulatingSampleDb.AddTrainToDb("HighRail", "515");
            //PopulatingSampleDb.AddTrainToDb("CommonRail", "616");
            //PopulatingSampleDb.AddTrainToDb("Rapide", "717");
            //PopulatingSampleDb.AddTrainToDb("InterCity", "818");

            PopulatingSampleDb.AddTrainToDb("PanEuropean", "919");
            PopulatingSampleDb.AddTrainToDb("Softronic", "232");
            PopulatingSampleDb.AddTrainToDb("NavigationExp", "656");

            PopulatingSampleDb.AddStationToDb("Craiova");
            PopulatingSampleDb.AddStationToDb("Bucuresti");
            PopulatingSampleDb.AddRouteToDb("Craiova", "Bucuresti", "656");


            PopulatingSampleDb.AddStationToDb("Constanta");
            PopulatingSampleDb.AddStationToDb("Brasov");
            PopulatingSampleDb.AddRouteToDb("Constanta", "Brasov", "232");

            PopulatingSampleDb.AddStationToDb("Constanta");
            PopulatingSampleDb.AddRouteToDb("Bucuresti", "Constanta", "919");


            Console.WriteLine("Done processing");
            Console.ReadLine();
        }



        













        


    }


} 


