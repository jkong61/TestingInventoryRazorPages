using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestingInventoryRazorPages.Data;
using TestingInventoryRazorPages.Models;
using TestingInventoryRazorPages.Services;

namespace TestingInventoryRazorPages.Pages.StorageItems
{
    public class CreateModel : PageModel
    {
        private readonly IStorageItemService _service;

        public CreateModel(IStorageItemService storageItemService)
        {
            _service = storageItemService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StorageItem StorageItem { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (await _service.AddAsync(StorageItem))
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
