using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }
        [SecuredOperation("book.add,admin")]
        public IResult AddBook(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult();
        }

        public IResult DeleteBook(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult();
        }


        public IResult UpdateBook(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult();
        }

        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        public IDataResult<List<BookDetailDto>> GetBookDetails()
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails());
        }

        public IDataResult<Book> GetById(int id)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(b=>b.Id==id));
        }
    }
}
