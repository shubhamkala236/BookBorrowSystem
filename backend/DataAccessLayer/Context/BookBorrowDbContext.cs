using Microsoft.EntityFrameworkCore;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class BookBorrowDbContext : DbContext
    {
        public BookBorrowDbContext(DbContextOptions<BookBorrowDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        //seeding users records in Database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User and lentBookList configuration
            modelBuilder.Entity<Book>()
                .HasOne(b => b.LentByUser)
                .WithMany(u => u.LentBooksList)
                .HasForeignKey(b => b.LentByUserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.BorrowedByUser)
                .WithMany(u => u.BorrowedBooksList)
                .HasForeignKey(b => b.BorrowedByUserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasData(
                   new User { UserId = 1, Name = "Rohan", Username = "user1", Password = "user123", TokensAvailable = 10 },
                   new User { UserId = 2, Name = "Shubham", Username = "user2", Password = "user123", TokensAvailable = 10 },
                   new User { UserId = 3, Name = "Rahul", Username = "user3", Password = "user123", TokensAvailable = 10 },
                   new User { UserId = 4, Name = "Rishabh", Username = "user4", Password = "user123", TokensAvailable = 10 }
              );

        }
    }
}
