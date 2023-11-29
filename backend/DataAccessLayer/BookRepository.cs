using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookRepository : IBookRepository
    {
        private readonly BookBorrowDbContext context;

        public BookRepository(BookBorrowDbContext context)
        {
            this.context = context;
        }

        //Add book
        public async Task<bool> AddBook(Book book)
        {
            bool alreadyPresent = await context.Books.AnyAsync(x => x.BookId == book.BookId);
            if (alreadyPresent)
            {
                return false;
            }
            
            await context.Books.AddAsync(book);
            return true;
        }

        //Borrow Book
        public async Task<bool> BorrowBook(int bookId, int borrowerUserId)
        {
            var book = await context.Books.FindAsync(bookId);

            if(book == null)
            {
                return false;
            }

            if(book.IsBookAvailable=="unavailable")
            {
                return false;
            }

            var borrower = await context.Users.FindAsync(borrowerUserId);
            if(borrower == null)
            {
                return false;
            }

            //check borrowers tokens
            if(borrower.TokensAvailable < 1)
            {
                return false;
            }

            //update book and borrower information
            book.IsBookAvailable = "unavailable";
            book.BorrowedByUserId = borrowerUserId;
            borrower.TokensAvailable -= 1;
            var lender = await context.Users.FindAsync(book.LentByUserId);
            if(lender!=null)
            {
                lender.TokensAvailable += 1;
            }

            if(lender.UserId == borrower.UserId)
            {
                return false;
            }

            return true;
        }
        //Return Book
        public async Task<bool> ReturnBook(int bookId, int borrowerUserId)
        {
            var book = await context.Books.FindAsync(bookId);

            if (book == null)
            {
                return false;
            }

            if (book.IsBookAvailable == "available")
            {
                return false;
            }

            var borrower = await context.Users.FindAsync(borrowerUserId);
            if (borrower == null)
            {
                return false;
            }

            if(book.BorrowedByUserId!=borrowerUserId)
            {
                return false;
            }


            //update book and borrower information
            book.IsBookAvailable = "available";
            book.BorrowedByUserId = null;

            return true;
        }


        //get all cars
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var cars = await context.Books.ToListAsync();
            return cars;
        }

        //get book by id
        public async Task<Book> GetBookById(int bookId)
        {
            var book = await context.Books.FindAsync(bookId);
            return book;
        }

        //Get my borrowed books
        public async Task<IEnumerable<Book>> GetMyBorrowedBooks(int myId)
        {
            var user = await context.Users
                        .Include(u => u.BorrowedBooksList)
                        .FirstOrDefaultAsync(u => u.UserId == myId);
            if(user == null)
            {
                return null;
            }

            var borrowedList = user.BorrowedBooksList;

            return borrowedList;
        }

        //get mylent books
        public async Task<IEnumerable<Book>> GetMyLentBooks(int myId)
        {
            var user = await context.Users
                        .Include(u => u.LentBooksList)
                        .FirstOrDefaultAsync(u => u.UserId == myId);
            if (user == null)
            {
                return null;
            }

            var LentList = user.LentBooksList;

            return LentList;
        }


    }
}
