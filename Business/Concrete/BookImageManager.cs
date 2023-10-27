using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookImageManager : IBookImageService
    {
        IBookImageDal _bookImageDal;
        IFileHelperService _fileHelperService;


        public BookImageManager(IBookImageDal bookImageDal, IFileHelperService fileHelperService)
        {
            _bookImageDal = bookImageDal;
            _fileHelperService = fileHelperService;

        }


        public IResult Add(IFormFile file, BookImage bookImage)
        {
            IResult result = BusinessRules.Run(CheckForCarImageLimit(bookImage.BookId));
            if (result != null)
            {
                return result;
            }
            bookImage.ImagePath = _fileHelperService.Upload(file, PathConstants.BookImagesPath);
            bookImage.Date = DateTime.Now;

            _bookImageDal.Add(bookImage);
            return new SuccessResult();

        }

        public IResult Delete(BookImage carImage)
        {
            _fileHelperService.Delete(PathConstants.BookImagesPath + carImage.ImagePath);
            _bookImageDal.Delete(carImage);

            return new SuccessResult();

        }

        public IDataResult<BookImage> GetById(int id)
        {
            return new SuccessDataResult<BookImage>(_bookImageDal.Get(i => i.Id == id));

        }

        public IResult Update(IFormFile file, BookImage bookImage)
        {
            //Firstly Update the ImageFilePath
            bookImage.ImagePath = _fileHelperService.Update(file, PathConstants.BookImagesPath + bookImage.ImagePath,
                PathConstants.BookImagesPath);
            bookImage.Date = DateTime.Now;
            _bookImageDal.Update(bookImage);
            return new SuccessResult();
        }
        public IDataResult<List<BookImage>> GetAll()
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll());
        }

        public IDataResult<List<BookImage>> GetImagesByBookId(int id)
        {
            IResult result = BusinessRules.Run(CheckImageExists(id));
            if (result != null)
            {
                return new ErrorDataResult<List<BookImage>>(GetDefaultImage(id).Data);
            }

            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll(c => c.BookId == id));
        }

        private IResult CheckForCarImageLimit(int bookId)
        {
            var result = _bookImageDal.GetAll(i => i.BookId == bookId).Count;
            if (result > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }

        private IResult CheckImageExists(int carId)
        {
            var result = _bookImageDal.GetAll(i => i.BookId == carId).Count;

            if (result > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }
        private IDataResult<List<BookImage>> GetDefaultImage(int bookId)
        {

            List<BookImage> bokImages = new List<BookImage>();

            bokImages.Add(new BookImage { BookId = bookId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });

            return new SuccessDataResult<List<BookImage>>(bokImages);
        }
    }
}
