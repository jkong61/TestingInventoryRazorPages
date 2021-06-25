using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingInventoryRazorPages.Models;
using TestingInventoryRazorPages.Services;

namespace TestingInventoryRazorPages.Pages.StorageItems
{
    public class EditModel : PageModel
    {
        private readonly StorageItemService _service;

        public EditModel(StorageItemService storageItemService)
        {
            _service = storageItemService;
        }

        [BindProperty]
        [Display(Name = "Description")]
        [PageRemote(
            ErrorMessage = "Description already exists.",
            AdditionalFields = "__RequestVerificationToken",
            HttpMethod = "post",
            PageHandler = "CheckDescription"
        )]
        public string Description { get; set; }
        [BindProperty]
        public StorageItem StorageItem { get; set; }
        public async Task<IActionResult> OnPostCheckDescriptionAsync()
        {
            var result = await _service.EntityItemExistsAsync(e =>
                string.Equals(e.Description.ToLower(), Description.ToLower()));
            return new JsonResult(!result);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StorageItem = await _service.FirstAsync(id);

            if (StorageItem == null)
            {
                return NotFound();
            }

            Description = StorageItem.Description;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            StorageItem.Description = Description;
            try
            {
                await _service.UpdateAsync(StorageItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _service.EntityItemExistsAsync(e => e.Id == StorageItem.Id))
                {
                    return NotFound();
                }
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
