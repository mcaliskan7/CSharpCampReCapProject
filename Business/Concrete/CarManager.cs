using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.CrossCuttingCorcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {            
            ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 01 || DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<Car>> (Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>> (_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car> (_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {           
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {          
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.BrandId == brandId));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {           
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 01 || DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<CarDetailDto>> (Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }
    }
}