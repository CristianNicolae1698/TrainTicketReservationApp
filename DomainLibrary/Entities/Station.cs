using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Entities
{
    public class Station
    {
        public Guid Id { get; set; }
        public string StationName { get; set; }

        public List<Route> Routes { get; set;}
    }
}
