
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Data.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=postgres;Password=root;Server=localhost;Port=5432;Database=libraryDBUpdated;Pooling=true;",
                    b => b.MigrationsAssembly("Data")); // Specify your migrations assembly name ('API' in this case)
            }
        }




        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
          .HasOne(b => b.Author)
          .WithMany(a => a.Books)
          .HasForeignKey(b => b.AuthorId)
          .OnDelete(DeleteBehavior.Cascade);

            //fluent api

            modelBuilder.Entity<Author>()
                .HasOne(a => a.Address)
                .WithOne(ad => ad.Author)

                .HasForeignKey<Address>(ad => ad.AuthorId);



            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
        }


    }
}
