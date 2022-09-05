using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrainTickets.Models
{
    public class Booking
    {
        public Guid Id{ get; set; }
        public List<Client> Clients{ get; set; }=new List<Client>();

        public List<Route> Routes { get; set; }=new List<Route>();

        public List<Train> Trains { get; set; }=new List<Train>();

        public string BookingDate { get; set; }

        public int Price { get; set; }
        public bool CheckedIn { get; set; }

    }
}
