using FluentValidation;
using RezerwacjaPOL.Models;
using RezerwacjaPOLLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Models.Validators
{
    public class SearchVMValidator : AbstractValidator<SearchEngineModel>
    {
        public SearchVMValidator()
        {
             RuleFor(x=>x.Title).NotEmpty().Length(1, 1000);
             RuleFor(x => x.Description).NotEmpty().Length(5, 1000);
             RuleFor(x => x.PhoneNumber).NotEmpty().Length(6, 12);
        }
       
    }
}
