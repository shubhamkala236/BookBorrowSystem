using SharedLayer.Dto;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class BookBLL : IBookBLL
    {
        private readonly IUnitOfWork uow;
        public BookBLL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        //add a book
        public async Task<bool> AddBook(AddBookDTO book, int userId)
        {
            var newBook = new Book
            {
                BookName = book.BookName,
                Rating = book.Rating,
                Author = book.Author,
                Genre = book.Genre,
                IsBookAvailable = "available",
                Description = book.Description,
                LentByUserId = userId,
            };

            var result = await uow.BookRepository.AddBook(newBook);
            await uow.SaveAsync();
            return result;
        }

        //Borrow Book
        public async Task<bool> BorrowBook(int bookId,int borrowerUserId)
        {
            var book = await uow.BookRepository.BorrowBook(bookId, borrowerUserId);

            if(!book)
            {
                return false;
            }

            await uow.SaveAsync();
            return book;
        }
        //Return Book
        public async Task<bool> ReturnBook(int bookId,int borrowerUserId)
        {
            var book = await uow.BookRepository.ReturnBook(bookId, borrowerUserId);

            if(!book)
            {
                return false;
            }

            await uow.SaveAsync();
            return book;
        }

        //get book by id
        public async Task<Book> GetBookById(int bookId)
        {
            var book = await uow.BookRepository.GetBookById(bookId);
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var result = await uow.BookRepository.GetAllBooks();
            var list = result.ToList();
            return list;

        }

        //get my borrow book list
        public async Task<IEnumerable<Book>> GetMyBorrowedBooks(int myId)
        {
            var result = await uow.BookRepository.GetMyBorrowedBooks(myId);
            var list = result.ToList();
            return list;
        }

        //get my lent book list
        public async Task<IEnumerable<Book>> GetMyLentBooks(int myId)
        {
            var result = await uow.BookRepository.GetMyLentBooks(myId);
            var list = result.ToList();
            return list;
        }
    }
}
