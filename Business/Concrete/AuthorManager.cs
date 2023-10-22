using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public IResult AddAuthor(Author author)
        {
            _authorDal.Add(author);
            return new SuccessResult();
        }

        public IResult DeleteAuthor(Author author)
        {
            _authorDal.Delete(author);
            return new SuccessResult();
        }

        public IDataResult<List<Author>> GetAll()
        {
            return new SuccessDataResult<List<Author>>(_authorDal.GetAll());
        }

        public IDataResult<Author> GetById(int id)
        {
            return new SuccessDataResult<Author>(_authorDal.Get(a => a.AuthorId == id));
        }

        public IResult UpdateAuthor(Author author)
        {
            _authorDal.Update(author);
            return new SuccessResult();
        }
    }
}
