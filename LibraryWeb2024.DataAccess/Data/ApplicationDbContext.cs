using LibraryWeb2024.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWeb2024.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        // BASIC CONFIGURATION THAT IS NEEDED FOR ENTITY FRAMEWORK:
        /*
         * DbContext - Root class for ENTITY FRAMEWORK CORE using which we will be able to access entity framework
         * In constructor we have to pass the connection string
         */

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        // SETUP FOR CATEGORY TABLE:
        public DbSet<Category> Categories { get; set; }

        // DEFAULT DATA:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add-migration SeedCategoryTable
            // update-database
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Fantasy", DisplayOrder = 1 },
               new Category { Id = 2, Name = "Horror", DisplayOrder = 2 },
               new Category { Id = 3, Name = "Lectures", DisplayOrder = 3 },
               new Category { Id = 4, Name = "SciFi", DisplayOrder = 4 },
               new Category { Id = 5, Name = "Historical", DisplayOrder = 5 }
            );
        }
    }
}
