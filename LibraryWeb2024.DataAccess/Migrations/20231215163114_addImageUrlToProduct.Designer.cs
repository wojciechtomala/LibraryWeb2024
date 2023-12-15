﻿// <auto-generated />
using LibraryWeb2024.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryWeb2024.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231215163114_addImageUrlToProduct")]
    partial class addImageUrlToProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryWeb2024.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Lectures"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "SciFi"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 5,
                            Name = "Historical"
                        });
                });

            modelBuilder.Entity("LibraryWeb2024.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price100")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price50")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Stanisław Wyspiański",
                            CategoryId = 1,
                            Description = "Dramat autorstwa Stanisława Wyspiańskiego, wystawiony po raz pierwszy w Teatrze Miejskim w Krakowie 16 marca 1901 roku w reżyserii Adolfa Walewskiego. Dramat ten uważany jest za jedno z najważniejszych dzieł epoki Młodej Polski; przyniósł on autorowi wielką sławę",
                            ISBN = "2847284301",
                            ImageUrl = "",
                            ListPrice = 30m,
                            Price = 25m,
                            Price100 = 15m,
                            Price50 = 20m,
                            Title = "Wesele"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Stanisław Wyspiański",
                            CategoryId = 2,
                            Description = "Dramat autorstwa Stanisława Wyspiańskiego, wystawiony po raz pierwszy w Teatrze Miejskim w Krakowie 16 marca 1901 roku w reżyserii Adolfa Walewskiego. Dramat ten uważany jest za jedno z najważniejszych dzieł epoki Młodej Polski; przyniósł on autorowi wielką sławę",
                            ISBN = "2847284301",
                            ImageUrl = "",
                            ListPrice = 30m,
                            Price = 25m,
                            Price100 = 15m,
                            Price50 = 20m,
                            Title = "Pan Tadeusz"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Stanisław Wyspiański",
                            CategoryId = 1,
                            Description = "Dramat autorstwa Stanisława Wyspiańskiego, wystawiony po raz pierwszy w Teatrze Miejskim w Krakowie 16 marca 1901 roku w reżyserii Adolfa Walewskiego. Dramat ten uważany jest za jedno z najważniejszych dzieł epoki Młodej Polski; przyniósł on autorowi wielką sławę",
                            ISBN = "2847284301",
                            ImageUrl = "",
                            ListPrice = 30m,
                            Price = 25m,
                            Price100 = 15m,
                            Price50 = 20m,
                            Title = "Dziady cz III"
                        });
                });

            modelBuilder.Entity("LibraryWeb2024.Models.Product", b =>
                {
                    b.HasOne("LibraryWeb2024.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
