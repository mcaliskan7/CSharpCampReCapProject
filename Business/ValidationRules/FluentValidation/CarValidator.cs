using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty().WithMessage(Messages.BrandIdInvalid);
            RuleFor(c => c.ColorId).NotEmpty().WithMessage(Messages.ColorIdInvalid);
            RuleFor(c => c.ModelYear).NotEmpty().WithMessage(Messages.ModelYearInvalid);
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(Messages.DailyPriceInvalid);
        }
    }
}