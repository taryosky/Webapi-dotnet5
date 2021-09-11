using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Webapi_dotnet5.Data.Dtos;
using Webapi_dotnet5.Data.Models;

namespace Webapi_dotnet5.Data.Services
{
    public class BookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(AddBookDto bookToAdd)
        {
            var book = new Book
            {
                Title = bookToAdd.Title,
                Author = bookToAdd.Author,
                CoverUrl = bookToAdd.CoverUrl,
                DateAdded = DateTime.Now,
                IsRead = bookToAdd.IsRead,
                DateRead = bookToAdd.IsRead ? bookToAdd.DateRead : null,
                Rate = bookToAdd.IsRead ? bookToAdd.Rate : null,
                Description = bookToAdd.Description,
                Genre = bookToAdd.Genre
            };
             
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public List<Book> GetBooks() => _context.Books.ToList();

        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(x => x.Id == bookId);
    }
}
