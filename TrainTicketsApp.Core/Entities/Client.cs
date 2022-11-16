using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Entities
{
    public class Client : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}

        public List<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
