using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestingInventoryRazorPages.Models
{
    public interface IStorageItem
    {
        int Id { get; set; }
    }

    [Index(nameof(Description), IsUnique = true)]
    public class StorageItem : IStorageItem
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public int Quantity { get; set; }

    }
}
