using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
         Task<T> InsertAsync(T item);
         Task<T> UpdateAsync(int id, T item);
         Task<bool> DeleteAsync(int id);
         Task<T> SelectAsync(int id);
         Task<IEnumerable<T>> SelectAsync();
         Task<bool> ExistAsync(int id);
    }
}