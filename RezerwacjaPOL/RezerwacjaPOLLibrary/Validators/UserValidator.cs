using FluentValidation;
using RezerwacjaPOLLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Length(300);
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
