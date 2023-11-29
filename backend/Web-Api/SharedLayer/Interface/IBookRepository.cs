using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface IBookRepository
    {
        //get all books
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int bookId);
        Task<IEnumerable<Book>> GetMyBorrowedBooks(int myId);
        //add book
        Task<bool> AddBook(Book book);
        //borrow book
        Task<bool> BorrowBook(int bookId, int borrowerUserId);
        Task<bool> ReturnBook(int bookId, int borrowerUserId);
        //my lent book list
        Task<IEnumerable<Book>> GetMyLentBooks(int myId);
    }
}
