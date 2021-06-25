using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingInventoryRazorPages.Data;
using TestingInventoryRazorPages.Models;

namespace TestingInventoryRazorPages.Services
{
    public class StorageItemService : IEntityService<StorageItem>
    {
        private readonly ApplicationDbContext _context;

        public StorageItemService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IList<StorageItem>> GetAllAsync()
        {
            return await _context.StorageItem.ToListAsync();
        }

        public async Task<StorageItem> FirstAsync(int? id)
        {
            return await _context.StorageItem.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> UpdateAsync(StorageItem item)
        {
            bool success;
            _context.Attach(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                success = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch
            {
                success = false;
            }
            return success;
        }

        public async Task<bool> AddAsync(StorageItem item)
        {
            bool success;
            await _context.StorageItem.AddAsync(item);
            try
            {
                await _context.SaveChangesAsync();
                success = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch
            {
                success = false;
            }
            return success;
        }

        public async Task<bool> EntityItemExistsAsync(Expression<Func<StorageItem, bool>> condition)
        {
            return await _context.StorageItem.AnyAsync(condition);
        }
    }
}