using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWeb2024.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1,1000)]
        public decimal ListPrice { get; set; }

        [Required]
        [Display(Name = "List Price 1-50")]
        [Range(1, 1000)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "List Price 50-100")]
        [Range(1, 1000)]
        public decimal Price50 { get; set; }

        [Required]
        [Display(Name = "List Price 100+")]
        [Range(1, 1000)]
        public decimal Price100 { get; set; }

        public int CategoryId { get; set; }
        // FOREIGN KEY NAVIGATION
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        // BOOK IMAGE:
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
