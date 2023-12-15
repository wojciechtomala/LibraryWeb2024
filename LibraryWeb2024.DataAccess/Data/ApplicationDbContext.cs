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
        // SETUP FOR PRODUCT TABLE:
        public DbSet<Product> Products { get; set; }

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

            modelBuilder.Entity<Product>().HasData(
               new Product { 
                    Id = 1,
                    Title = "Wesele",
                    Description = "Dramat autorstwa Stanisława Wyspiańskiego, wystawiony po raz pierwszy w Teatrze Miejskim w Krakowie 16 marca 1901 roku w reżyserii Adolfa Walewskiego. Dramat ten uważany jest za jedno z najważniejszych dzieł epoki Młodej Polski; przyniósł on autorowi wielką sławę",
                    Author = "Stanisław Wyspiański",
                    ISBN = "2847284301",
                    ListPrice = 30,
                    Price = 25,
                    Price50 = 20,
                    Price100 = 15,
                    CategoryId = 1,
                    ImageUrl = ""
               },
               new Product { 
                    Id = 2,
                    Title = "Pan Tadeusz",
                    Description = "Dramat autorstwa Stanisława Wyspiańskiego, wystawiony po raz pierwszy w Teatrze Miejskim w Krakowie 16 marca 1901 roku w reżyserii Adolfa Walewskiego. Dramat ten uważany jest za jedno z najważniejszych dzieł epoki Młodej Polski; przyniósł on autorowi wielką sławę",
                    Author = "Stanisław Wyspiański",
                    ISBN = "2847284301",
                    ListPrice = 30,
                    Price = 25,
                    Price50 = 20,
                    Price100 = 15,
                    CategoryId = 2,
                    ImageUrl = ""
               },
               new Product { 
                    Id = 3,
                    Title = "Dziady cz III",
                    Description = "Dramat autorstwa Stanisława Wyspiańskiego, wystawiony po raz pierwszy w Teatrze Miejskim w Krakowie 16 marca 1901 roku w reżyserii Adolfa Walewskiego. Dramat ten uważany jest za jedno z najważniejszych dzieł epoki Młodej Polski; przyniósł on autorowi wielką sławę",
                    Author = "Stanisław Wyspiański",
                    ISBN = "2847284301",
                    ListPrice = 30,
                    Price = 25,
                    Price50 = 20,
                    Price100 = 15,
                    CategoryId = 1,
                    ImageUrl = ""
               }
            );
        }
    }
}
