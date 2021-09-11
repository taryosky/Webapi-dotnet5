using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Webapi_dotnet5.Data.Dtos;
using Webapi_dotnet5.Data.Services;

namespace Webapi_dotnet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpGet("{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
            return Ok(_bookService.GetBookById(bookId));
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] AddBookDto bookToAdd)
        {
            _bookService.AddBook(bookToAdd);
            return Ok();
        }
    }
}
