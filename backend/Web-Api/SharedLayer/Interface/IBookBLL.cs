using SharedLayer.Dto;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface IBookBLL
    {
        //get all Books
        Task<IEnumerable<Book>> GetAllBooks();
        //get my borrowed books
        Task<IEnumerable<Book>> GetMyBorrowedBooks(int myId);
        Task<IEnumerable<Book>> GetMyLentBooks(int myId);
        Task<Book> GetBookById(int bookId);
        //add book
        Task<bool> AddBook(AddBookDTO book, int userId);

        //borrow book
        Task<bool> BorrowBook(int bookId,int borrowerUserId);
        Task<bool> ReturnBook(int bookId,int borrowerUserId);
    }
}
