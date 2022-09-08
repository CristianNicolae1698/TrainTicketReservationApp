using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrainTickets.Models
{
    public class Route
    {
        public Guid Id { get; set; }
        public string RouteName { get; set; }

        public List<Station> Stations { get; set; }=new List<Station>();
        public List<Train> Trains { get; set; } =new List<Train>();

        
        public int StationOrder { get; set; }


    }
}
