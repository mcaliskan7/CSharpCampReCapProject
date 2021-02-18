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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 01 || DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>> (_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color> (_colorDal.Get(c => c.Id == id));
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);

            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}