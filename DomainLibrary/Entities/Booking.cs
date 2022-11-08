using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Entities
{
    public class Booking : Entity
    {

        public Route Route { get; set; }

        public Train Train { get; set; }

        public DateTime BookingDate { get; set; }

        public int Price { get; set; }

    }
}
