using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
                                 BookName = b.BookName, AuthorFirstName = a.AuthorFirstName,
                                 AuthorLastName = a.AuthorLastName, CategoryName = c.CategoryName,
                                 PublishedYear = b.PublishedYear
                             };
                return result.ToList();
            }
        }
    }
}
