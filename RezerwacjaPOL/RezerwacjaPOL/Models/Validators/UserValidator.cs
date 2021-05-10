﻿using FluentValidation;
using RezerwacjaPOLLibrary.Models;
using RezerwacjaPOLLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.Validators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(2,45);
            RuleFor(x => x.LastName).NotEmpty().Length(2,90);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Length(300);
            RuleFor(x => x.Password).NotEmpty().Length(6,48);

        }
    }
}
