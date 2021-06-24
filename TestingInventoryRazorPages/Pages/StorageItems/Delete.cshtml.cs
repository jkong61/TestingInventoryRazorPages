using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingInventoryRazorPages.Data;
using TestingInventoryRazorPages.Models;

namespace TestingInventoryRazorPages.Pages.StorageItems
{
    public class DeleteModel : PageModel
    {
        private readonly TestingInventoryRazorPages.Data.ApplicationDbContext _context;

        public DeleteModel(TestingInventoryRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StorageItem StorageItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StorageItem = await _context.StorageItem.FirstOrDefaultAsync(m => m.Id == id);

            if (StorageItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StorageItem = await _context.StorageItem.FindAsync(id);

            if (StorageItem != null)
            {
                _context.StorageItem.Remove(StorageItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
