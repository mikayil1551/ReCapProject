using Entities.Concrete;
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
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("FirstName boş olamaz");
            RuleFor(p => p.FirstName).MinimumLength(2);
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password boş olamaz");
            RuleFor(p => p.FirstName).Must(StartWithA).WithMessage("Araba isimleri A harfi ile başlamalı");
        }


        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

