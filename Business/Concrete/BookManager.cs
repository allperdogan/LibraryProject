using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BookValidator))]
        public IResult AddBook(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult DeleteBook(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BookValidator))]
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

        public IDataResult<BookDetailDto> GetById(int id)
        {
            return new SuccessDataResult<BookDetailDto>(_bookDal.GetAllBookDetails(b=>b.Id==id).SingleOrDefault());
        }

        public IDataResult<List<BookDetailDto>> GetByCategory(int id)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetAllBookDetails(b => b.CategoryId == id));
        }

        public IDataResult<List<BookDetailDto>> GetByAuthor(int id)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetAllBookDetails(b => b.AuthorId == id));
        }
    }
}
