using NUnit.Framework;
using RezerwacjaPOL.Models;
using RezerwacjaPOLLibrary.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjePOLTest
{
    class AddAuctionVMValidatorTests
    {
        [Test]
        public void ShouldNotValidateIfTitleIsTooShort()
        {
            var auctionVM = new AuctionViewModel
            {
                Title = "short",
                Description = "Description is of good length",
                PhoneNumber = "12345678910"
            };
            var validator = new AuctionVMValidator();
            var result = validator.Validate(auctionVM);
            Assert.IsFalse(result.IsValid);
        }

        [Test]
        public void ShouldValidateIfEveryPropertyIsOfGoodLength()
        {
            var auctionVM = new AuctionViewModel
            {
                Title = "Title is of good length",
                Description = "Description is of good length",
                PhoneNumber = "12345678910"
            };

            var validator = new AuctionVMValidator();
            var result = validator.Validate(auctionVM);
            Assert.IsTrue(result.IsValid);
        }

        [Test]
        public void ShouldNotValidateIfPhoneNumberIsNotProvided()
        {
            var auctionVM = new AuctionViewModel
            {
                Title = "short",
                Description = "Description is of good length",
            };
            var validator = new AuctionVMValidator();
            var result = validator.Validate(auctionVM);
            Assert.IsFalse(result.IsValid);
        }
    }
}
