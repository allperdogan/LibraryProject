using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBookDal : IEntityRepository<Book>
    {
        List<BookDetailDto> GetBookDetails();
        List<BookDetailDto> GetAllBookDetails(Expression<Func<BookDetailDto, bool>> filter = null);
        List<BookStatusDto> GetAllBookReservationDetails(Expression<Func<BookStatusDto, bool>> filter = null);
    }
}
