using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestingInventoryRazorPages.Models;

namespace TestingInventoryRazorPages.Services
{
    public interface IStorageItemService : IEntityService<StorageItem>
    {
        Task<bool> AddAsync(StorageItem item);
        Task<bool> EntityItemExistsAsync(Expression<Func<StorageItem, bool>> condition);
        Task<StorageItem> FirstAsync(int? id);
        Task<IList<StorageItem>> GetAllAsync();
        Task<bool> RemoveAsync(StorageItem item);
        Task<bool> UpdateAsync(StorageItem item);
    }
}