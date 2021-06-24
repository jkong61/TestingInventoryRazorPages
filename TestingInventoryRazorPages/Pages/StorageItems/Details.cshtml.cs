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
    public class DetailsModel : PageModel
    {
        private readonly TestingInventoryRazorPages.Data.ApplicationDbContext _context;

        public DetailsModel(TestingInventoryRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
