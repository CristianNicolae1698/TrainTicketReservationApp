using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Entities
{
    public class Station : Entity
    {
        public string StationName { get; set; }

        public List<Route> Routes { get; set;}=new List<Route>();
    }
}
