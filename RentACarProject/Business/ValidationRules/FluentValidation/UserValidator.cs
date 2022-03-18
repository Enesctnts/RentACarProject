﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).Must(ToUpper).WithMessage("Sifrende buyuk harf olmalidir.");
            RuleFor(p => p.Password).MinimumLength(7);
            RuleFor(p => p.UserId).NotEmpty();
        }
        private bool ToUpper(string arg)
        {
            return arg.Any(p => arg.Contains(p));
        }
    }
}