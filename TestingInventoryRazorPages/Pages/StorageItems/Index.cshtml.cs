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
    public class IndexModel : PageModel
    {
        private readonly StorageItemService _service;

        public IndexModel(StorageItemService storageItemService)
        {
            _service = storageItemService;
        }

        public IList<StorageItem> StorageItem { get;set; }

        public async Task OnGetAsync()
        {
            StorageItem = await _service.GetAllAsync();
        }
    }
}
