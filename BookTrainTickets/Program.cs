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

            PopulateDBMethods.CreateRoute();

            Console.WriteLine("Done processing");
            Console.ReadLine();
        }



        













        


    }


} 


