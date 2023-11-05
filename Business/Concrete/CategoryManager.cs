using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult AddCategory(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult();
        }

        //[SecuredOperation("admin")]
        public IResult DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
           return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(b=>b.CategoryId==id));
        }

        public IResult GetIdByName(string name)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(b => b.CategoryName == name));
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }
    }
}
