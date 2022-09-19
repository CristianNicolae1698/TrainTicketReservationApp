using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTrainTickets.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T>GetById (Guid id);

        Task<bool> Add(T entity);

        Task<bool> Delete(Guid id);

        Task<bool> Upsert(T entity);










    }
}
