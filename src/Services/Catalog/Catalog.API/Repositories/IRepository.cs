using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API
{
    public interface IRepository<T> where T : IEntityBase
    {
        Task<IEnumerable<T>> GetItems();
        Task<T> GetItem(string id);
        Task CreateItem(T product);
        Task<bool> UpdateItem(T product);
        Task<bool> DeleteItem(string id);
    }
}
