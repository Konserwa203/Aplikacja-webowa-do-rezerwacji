using FluentValidation;
using RezerwacjaPOLLibrary.Models;
using RezerwacjaPOLLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.Validators
{
    public class UserVMValidator : AbstractValidator<UserViewModel>
    {
        public UserVMValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Pole jest wymagane").MinimumLength(2).WithMessage("Imię jest za krótkie").MaximumLength(45).WithMessage("Imię jest za długie");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Pole jest wymagane").MinimumLength(2).WithMessage("Nazwisko jest za krótkie").MaximumLength(45).WithMessage("Nazwisko jest za długie");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Pole jest wymagane").EmailAddress().WithMessage("Email jest nieprawidłowy").MinimumLength(10).WithMessage("Email jest za krótki").MaximumLength(300).WithMessage("Email jest za długi");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Pole jest wymagane").MinimumLength(6).WithMessage("Hasło jest za krótkie").MaximumLength(45).WithMessage("Hasło jest za długie");

        }
    }
}
