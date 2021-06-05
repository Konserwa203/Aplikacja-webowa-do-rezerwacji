using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Models.Validators
{
    public class LoginVMValidator : AbstractValidator<LoginViewModel>
    {
        public LoginVMValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Pole jest wymagane").EmailAddress().WithMessage("Email jest nieprawidłowy").MinimumLength(10).WithMessage("Email jest za krótki").MaximumLength(300).WithMessage("Email jest za długi");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Pole jest wymagane").MinimumLength(6).WithMessage("Hasło jest za krótkie").MaximumLength(45).WithMessage("Hasło jest za długie");
        }
    }
}
