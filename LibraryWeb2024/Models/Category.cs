using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWeb2024.Models
{
    public class Category
    {
        [Key] // KEY DATA ALOCATION TO EXPLICITLY TELL TO DATABASE THAT ITS THE PRIMARY KEY
        public int Id { get; set; } // PRIMARY KEY OF THE TABLE
        
        [Required] // REQUIRED DATA ALOCATION
        [DisplayName("Category Name")]
        [MaxLength(200)]
        public string Name { get; set; }
        // DATA ALLOCATIONS:
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "Display Order must be between 1-100 characters")]
        public int DisplayOrder { get; set; }
    }
}
