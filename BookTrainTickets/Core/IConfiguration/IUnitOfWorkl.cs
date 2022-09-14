using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookTrainTickets.Core.IRepositories;
namespace BookTrainTickets.Core.IConfiguration
{
    public interface IUnitOfWorkl
    {
        IRouteRepository Routes { get; set; }

        Task CompleteAsync();
    }
}
