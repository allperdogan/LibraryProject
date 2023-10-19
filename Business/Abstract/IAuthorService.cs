using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IDataResult<List<Author>> GetAll();
        IResult AddAuthor(Author author);
        IResult UpdateAuthor(Author author);
        IResult DeleteAuthor(Author author);
    }
}
