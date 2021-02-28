using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(FileHelper.DeleteAsync(_carImageDal.Get(cim => cim.Id == carImage.Id).ImagePath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageExists(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageExists(carId).Data);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(cim => cim.Id == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.UpdateAsync(_carImageDal.Get(cim => cim.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IDataResult<List<CarImage>> CheckIfCarImageExists(int carId)
        {
            try
            {
                string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\default.jpg");
                var result = _carImageDal.GetAll(cim => cim.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(cim => cim.CarId == carId).ToList());
        }

        private IResult CheckIfImageLimit(int carId)
        {
            var carImageCount = _carImageDal.GetAll(cim => cim.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
    }
}