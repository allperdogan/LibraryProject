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
        

        public List<BookDetailDto> GetBookDetails()
        {
            using (LibraryProjectContext context = new LibraryProjectContext())
            {
                var result = from b in context.Books
                             join a in context.Authors
                             on b.AuthorId equals a.AuthorId
                             join c in context.Categories
                             on b.CategoryId equals c.CategoryId
                             select new BookDetailDto 
                             {
                                 Id = b.Id ,BookName = b.BookName, AuthorFirstName = a.AuthorFirstName,
                                 AuthorLastName = a.AuthorLastName, CategoryName = c.CategoryName,
                                 PublishedYear = b.PublishedYear, Summary = b.Summary
                             };
                return result.ToList();
            }
        }

        List<BookDetailDto> IBookDal.GetAllBookDetails(Expression<Func<BookDetailDto, bool>> filter)
        {
            using (LibraryProjectContext context = new LibraryProjectContext())
            {
                var result = from b in context.Books
                             join a in context.Authors
                             on b.AuthorId equals a.AuthorId
                             join c in context.Categories
                             on b.CategoryId equals c.CategoryId
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
                                 Summary = b.Summary
                                 
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }

        }
    }
}
