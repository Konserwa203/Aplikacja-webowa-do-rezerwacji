using FluentValidation;
using RezerwacjaPOLLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.Validators
{
    public class AuctionValidator : AbstractValidator<Auction>
    {
        public AuctionValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.CreatedOn).NotNull();
            RuleFor(x => x.Description).NotEmpty().MinimumLength(10).MaximumLength(750);
            RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(9).MaximumLength(12);
        }
    }
}
