using Business.Constants;
using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(Messages.FirstNameInvalid);
            RuleFor(u => u.LastName).NotEmpty().WithMessage(Messages.LastNameInvalid);
            RuleFor(u => u.Email).Must(ContainsAt).WithMessage(Messages.EmailInvalid);
            RuleFor(u => Encoding.UTF8.GetString(u.PasswordHash)).MinimumLength(6).WithMessage(Messages.PasswordInvalid);
        }

        private bool ContainsAt(string arg)
        {
            return arg.Contains("@");
        }
    }
}