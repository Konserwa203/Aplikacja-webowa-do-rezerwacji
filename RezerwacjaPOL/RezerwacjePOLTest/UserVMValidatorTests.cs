using NUnit.Framework;

using RezerwacjaPOL.Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RezerwacjaPOLLibrary.Validators;
using RezerwacjaPOLLibrary.ViewModels;

namespace RezerwacjePOLTest
{
    [TestFixture]
    public class UserVMValidatorTests
    {
        [Test]
        public void ShouldValidateIfAllRequiredPropertiesAreProvided()
        {
            var userVM = new UserViewModel
            {
                FirstName = "Mariusz",
                LastName = "Pudzianowski",
                Email = "Pudzian@ath.edu.pl",
                Password = "silneJakJa"
            };
            var validator = new UserVMValidator();
            var result = validator.Validate(userVM);
            Assert.IsTrue(result.IsValid);
        }

        [Test]
        public void ShouldNotValidateIfFirstNameIsNotProvided()
        {
            var userVM = new UserViewModel
            {
                LastName = "Pudzianowski",
                Email = "Pudzian@ath.edu.pl",
                Password = "silneJakJa"
            };
            var validator = new UserVMValidator();
            var result = validator.Validate(userVM);
            Assert.IsFalse(result.IsValid);
        }
        [Test]
        public void ShouldNotValidateIfLastNameIsNotProvided()
        {
            var userVM = new UserViewModel
            {
                LastName = "Pudzianowski",
                Email = "Pudzian@ath.edu.pl",
                Password = "silneJakJa"
            };
            var validator = new UserVMValidator();
            var result = validator.Validate(userVM);
            Assert.IsFalse(result.IsValid);
        }
        [Test]
        public void ShouldNotValidateIfEmailIsNotProvided()
        {
            var userVM = new UserViewModel
            {
                FirstName = "Mariusz",
                LastName = "Pudzianowski",
                Password = "silneJakJa"
            };
            var validator = new UserVMValidator();
            var result = validator.Validate(userVM);
            Assert.IsFalse(result.IsValid);
        }

    }
}
