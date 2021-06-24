using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestingInventoryRazorPages.Services
{
    public interface IEntityService<T>
    {
        public Task<IList<T>> GetAllAsync();
        public Task<bool> AddAsync(T item);

        public Task<bool> UpdateAsync(T item);

        public Task<T> FirstAsync(int? id);
    }
}