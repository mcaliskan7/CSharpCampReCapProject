using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.CrossCuttingCorcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 01 || DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>> (_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand> (_brandDal.Get(b => b.Id == id));
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);

            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}