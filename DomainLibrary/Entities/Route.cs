using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Entities
{
    public class Route : Entity
    {
        public string RouteName { get; set; }

        public List<Station> Stations { get; set; }=new List<Station>();
        public List<Train> Trains { get; set; }=new List<Train>();

        


    }
}
