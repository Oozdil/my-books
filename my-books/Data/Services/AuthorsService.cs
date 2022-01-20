using Data.Models;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
        public AuthorWithBooksVM GetAuthorWithBooks(int authorid)
        {
            var _author = _context.Authors.Where(n => n.Id == authorid).Select(n => new AuthorWithBooksVM()
            {
                FullName=n.FullName,
                BookTitles=n.Books_Authors.Select(n=>n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }
    }
}
