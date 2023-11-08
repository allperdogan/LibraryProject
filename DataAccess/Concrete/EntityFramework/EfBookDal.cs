using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, LibraryProjectContext>, IBookDal
    {
        public List<BookStatusDto> GetAllBookReservationDetails(Expression<Func<BookStatusDto, bool>> filter = null)
        {
            using (LibraryProjectContext context = new LibraryProjectContext())
            {
                var result = from b in context.Books
                             join r in context.Reservations
                             on b.Id equals r.BookId
                             select new BookStatusDto
                             {
                                 ReservationId = r.Id, 
                                 BookId = b.Id, 
                                 UserId = r.UserId, 
                                 ReserveDate = r.ReserveDate, 
                                 ReturnDate = r.ReturnDate
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public List<BookDetailDto> GetBookDetails()
        {
            using (LibraryProjectContext context = new LibraryProjectContext())
            {
                var result = from b in context.Books
                             join a in context.Authors
                             on b.AuthorId equals a.AuthorId
                             join c in context.Categories
                             on b.CategoryId equals c.CategoryId
                             join d in context.BookImages
                             on b.Id equals d.BookId
                             select new BookDetailDto 
                             {
                                 Id = b.Id ,
                                 CategoryId = b.CategoryId,
                                 AuthorId = b.AuthorId,
                                 BookName = b.BookName, 
                                 AuthorFirstName = a.AuthorFirstName,
                                 AuthorLastName = a.AuthorLastName, 
                                 CategoryName = c.CategoryName,
                                 PublishedYear = b.PublishedYear, 
                                 Summary = b.Summary,
                                 ImagePath = d.ImagePath, 
                                 Date = d.Date.ToString(),
                                 BookId = b.Id
                             };
                return result.ToList();
            }
        }

        public List<BookDetailDto> GetAllBookDetails(Expression<Func<BookDetailDto, bool>> filter)
        {
            using (LibraryProjectContext context = new LibraryProjectContext())
            {
                var result = from b in context.Books
                             join a in context.Authors
                             on b.AuthorId equals a.AuthorId
                             join c in context.Categories
                             on b.CategoryId equals c.CategoryId
                             join d in context.BookImages
                             on b.Id equals d.BookId
                             select new BookDetailDto
                             {
                                 Id = b.Id,
                                 CategoryId = b.CategoryId,
                                 AuthorId = b.AuthorId,
                                 BookName = b.BookName,
                                 AuthorFirstName = a.AuthorFirstName,
                                 AuthorLastName = a.AuthorLastName,
                                 CategoryName = c.CategoryName,
                                 PublishedYear = b.PublishedYear,
                                 Summary = b.Summary,
                                 ImagePath = d.ImagePath,
                                 Date = d.Date.ToString(),
                                 BookId = b.Id
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }

        }
    }
}
