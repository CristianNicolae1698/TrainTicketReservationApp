using BookTrainTickets.Core.IRepositories;
using BookTrainTickets.DataAccess;
using BookTrainTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrainTickets.Core.Repositories
{
    public class RouteRepository : GenericRepository<Route>,IRouteRepository
    {
        public RouteRepository(BookingContext context, ILogger logger):base(context, logger)
        {

        }


        public override async Task<IEnumerable<Route>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(RouteRepository));
                return new List<Route>();
            }
        }

        public override async Task<bool> Upsert(Route entity)
        {
            var existingRoute=await dbSet.Where(x=>x.Id==entity.Id).FirstOrDefaultAsync();

            if (existingRoute == null)
                return await Add(entity);
            
            existingRoute.RouteName=entity.RouteName;
            existingRoute.Id = entity.Id;

            return true;

            try
            {
                
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(RouteRepository));
                return false;
            }

        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist=await dbSet.Where(x=>x.Id == id).FirstOrDefaultAsync();
                if (exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(RouteRepository));
                return false;
            }
        }
    }
}
