﻿using Business.Abstract;
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

        IDataResult<List<Book>> IBookService.GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        IDataResult<List<BookDetailDto>> IBookService.GetBookDetails()
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails());
        }
    }
}