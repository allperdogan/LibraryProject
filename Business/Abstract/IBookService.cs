using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IDataResult<List<BookDetailDto>> GetBookDetails();
        IResult AddBook(Book book);
        IResult UpdateBook(Book book);
        IResult DeleteBook(Book book);
        IDataResult<BookDetailDto> GetById(int id);
        IDataResult<List<BookDetailDto>> GetByCategory(int id);
        IDataResult<List<BookDetailDto>> GetByAuthor(int id);
    }
}
