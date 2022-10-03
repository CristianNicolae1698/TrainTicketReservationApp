using DomainLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.EntityFrameworkCore;
namespace EFDataAccessLibrary
{
    public class BookingDBInitializer : DropCreateDatabaseIfModelChanges<BookingContext>
    {
        protected override void Seed(BookingContext context)
        {
            List<Train> trains=new List<Train>();
            trains.Add(new Train() { Id=Guid.NewGuid(), TrainNumber="2843724892", TrainType="MagLev"});
            trains.Add(new Train() { Id = Guid.NewGuid(), TrainNumber = "12355666", TrainType = "UrbanTrain" });


            context.Trains.AddRange(trains);

            base.Seed(context);
        }



    }
    

    
}
