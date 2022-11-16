using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Entities
{
    public class Train : Entity
    {
        
        public List<Route> Routes { get; set; } = new List<Route>();
        public string TrainNumber { get; set; }
        public string TrainType { get; set; }
    }
}
