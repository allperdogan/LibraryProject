using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBookDal : IBookDal
    {
        List<Book> _books;

        public InMemoryBookDal()
        {
            _books = new List<Book>() {
                new Book() { Id=1 , CategoryId=1, BookName="Suç ve Ceza", PublishedYear = 1990, Summary = "summary"},
                new Book() { Id=2 , CategoryId = 2, BookName = "Sefiller", PublishedYear = 1995, Summary = "summary2"},
                new Book() { Id=3 , CategoryId = 3, BookName = "Anna Karenina", PublishedYear = 1999, Summary = "summary3"},
            };
        }

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public void Delete(Book book)
        {
            Book deletedBook = _books.SingleOrDefault(b=>b.Id==book.Id);
            _books.Remove(deletedBook);
        }

        public Book Get(Expression<Func<Book, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public List<Book> GetAll(Expression<Func<Book, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<BookDetailDto> GetAllBookDetails(Expression<Func<Book, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<BookDetailDto> GetAllBookDetails(Expression<Func<BookDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<BookDetailDto> GetBookDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            Book updatedBook = _books.SingleOrDefault(b => b.Id == book.Id);
            updatedBook.CategoryId = book.CategoryId;
            updatedBook.BookName = book.BookName;
            updatedBook.PublishedYear = book.PublishedYear;
            updatedBook.Summary = book.Summary;
        }
    }
}
