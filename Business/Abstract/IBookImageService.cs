using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookImageService
    {
        IDataResult<List<BookImage>> GetImagesByBookId(int id);
        IDataResult<List<BookImage>> GetAll();
        IDataResult<BookImage> GetById(int id);
        IResult Add(IFormFile file, BookImage bookImage);
        IResult Update(IFormFile file, BookImage bookImage);
        IResult Delete(BookImage bookImage);
    }
}
