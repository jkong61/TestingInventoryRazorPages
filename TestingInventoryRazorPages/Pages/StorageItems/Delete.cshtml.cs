using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingInventoryRazorPages.Data;
using TestingInventoryRazorPages.Models;
using TestingInventoryRazorPages.Services;

namespace TestingInventoryRazorPages.Pages.StorageItems
{
    public class DeleteModel : PageModel
    {
        private readonly StorageItemService _storageItemService;

        public DeleteModel(StorageItemService storageItemService)
        {
            _storageItemService = storageItemService;
        }

        [BindProperty]
        public StorageItem StorageItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StorageItem = await _storageItemService.FirstAsync(id);

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

            StorageItem = await _storageItemService.FirstAsync(id);

            if (StorageItem != null)
            {
                await _storageItemService.RemoveAsync(StorageItem);
            }

            return RedirectToPage("./Index");
        }
    }
}
