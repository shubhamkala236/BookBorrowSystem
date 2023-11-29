using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLayer.Dto;
using SharedLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookBLL bookBLL;
        public BookController(IBookBLL bookBLL)
        {
            this.bookBLL = bookBLL;
        }

        //Get All Books Available
        [HttpGet("allBooks")]
        [AllowAnonymous] //any user
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var response = await bookBLL.GetAllBooks();
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(400, $"Error fetching Books:{e.Message}");
            }
        }

        //Add a Book
        //Add Book --- Logged in user
        [HttpPost("addBook")]
        public async Task<IActionResult> AddBook([FromForm] AddBookDTO book)
        {
            try
            {
                //get my userID
                var userId = GetCurrentUser();
                if (userId == 0)
                {
                    return Unauthorized();
                }

                var result = await bookBLL.AddBook(book,userId);
                if (result)
                {
                    return Ok("Book Added Successfully");
                }

                return StatusCode(409, $"Unable to Add Book");
            }
            catch (Exception e)
            {
                return StatusCode(400, $"Unable to Add Book:{e.Message}");
            }

        }

        //borrow book
        [HttpGet("borrowBook/{bookId}")]
        public async Task<IActionResult> BorrowBook(int bookId)
        {
            try
            {
                //get my userID
                var userId = GetCurrentUser();
                if (userId == 0)
                {
                    return Unauthorized();
                }

                var result = await bookBLL.BorrowBook(bookId, userId);
                if (result)
                {
                    return Ok("Book Borrowed Successfully");
                }

                return StatusCode(409, $"Unable to Borrow Book");
            }
            catch (Exception e)
            {
                return StatusCode(400, $"Unable to Borrow Book:{e.Message}");
            }

        }

        //Return book
        [HttpGet("ReturnBook/{bookId}")]
        public async Task<IActionResult> ReturnBook(int bookId)
        {
            try
            {
                //get my userID
                var userId = GetCurrentUser();
                if (userId == 0)
                {
                    return Unauthorized();
                }

                var result = await bookBLL.ReturnBook(bookId, userId);
                if (result)
                {
                    return Ok("Book Returned Successfully");
                }

                return StatusCode(409, $"Unable to Return Book");
            }
            catch (Exception e)
            {
                return StatusCode(400, $"Unable to Return Book:{e.Message}");
            }

        }

        //Get my borrowed book list
        [HttpGet("getMyBorrowedBooks")]
        //[AllowAnonymous] //any logged in user
        public async Task<IActionResult> GetMyBorrowedBooks()
        {
            try
            {
                //get my userID
                var userId = GetCurrentUser();
                if (userId == 0)
                {
                    return Unauthorized();
                }
                var response = await bookBLL.GetMyBorrowedBooks(userId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(400, $"Error fetching Books:{e.Message}");
            }
        }

        //Get my borrowed book list
        [HttpGet("getMyLentBooks")]
        //[AllowAnonymous] //any logged in user
        public async Task<IActionResult> GetMyLentBooks()
        {
            try
            {
                //get my userID
                var userId = GetCurrentUser();
                if (userId == 0)
                {
                    return Unauthorized();
                }
                var response = await bookBLL.GetMyLentBooks(userId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(400, $"Error fetching Books:{e.Message}");
            }
        }

        //get book by id
        [HttpGet("bookDetails/{bookId}")]
        [AllowAnonymous] //any user
        public async Task<IActionResult> GetBookById(int bookId)
        {
            try
            {
                var response = await bookBLL.GetBookById(bookId);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(404, $"No Book with detail found");
            }
            catch (Exception e)
            {
                return StatusCode(400, $"Unable to fetch Book Details:{e.Message}");
            }
        }


        //Get current logged in user
        private int GetCurrentUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            return 0;
        }
    }
}
