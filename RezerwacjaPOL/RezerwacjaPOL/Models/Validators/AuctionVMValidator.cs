using FluentValidation;
using RezerwacjaPOL.Models;
using RezerwacjaPOLLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.Validators
{
    public class AuctionVMValidator : AbstractValidator<AuctionViewModel>
    {
        public AuctionVMValidator()
        {

            RuleFor(x => x.Title).NotEmpty().Length(10, 70);
            RuleFor(x => x.Description).NotEmpty().Length(20, 1000);
            RuleFor(x => x.PhoneNumber).NotEmpty().Length(9, 12);
        }
    }
}
