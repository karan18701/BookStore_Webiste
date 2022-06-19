using BookStoreModels.Models;
using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepository
{
    public class BookRepository : BaseRepository
    {
        public ListResponse<Book> GetBooks(int pageIndex, int pageSize, string? keyword)
        {
            keyword = keyword?.ToLower()?.Trim();

            var query = _context.Books.Where(c => keyword == null || c.Name.ToLower().Contains(keyword));

            int totalRecords = query.Count();

            List<Book> books = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new ListResponse<Book>()
            {
                Records = books,
                TotalRecords = totalRecords
            };

        }

        public Book GetBook(int id)
        {
            return _context.Books.SingleOrDefault(c => c.Id == id);
        }

        public Book AddBook(Book book)
        {
            var entry = _context.Books.Add(book);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Book UpdateBook(Book book)
        {
            var entry = _context.Books.Update(book);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            if (book == null)
                return false;
            var entry = _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }
    }
}
