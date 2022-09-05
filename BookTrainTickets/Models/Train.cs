using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrainTickets.Models
{
    public class Train
    {
        public Guid Id { get; set; }
        
        public string TrainNumber { get; set; }
        public string TrainType { get; set; }
    }
}
