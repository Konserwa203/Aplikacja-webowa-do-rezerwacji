using NUnit.Framework;
using RezerwacjaPOL.Models;
using RezerwacjaPOL.Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjePOLTest
{
    [TestFixture]
    public class SearchVMValidatorTests
    {
        [Test]
        public void ShouldNotValidatePhoneNumberIsTooLong()
        {
            var searchEM = new SearchEngineModel
            {
                PhoneNumber = "11111111111111111111111111111111111",
                Title="Tytuł 1234567",
                Description="Opis 123456789"               
            };
            var validator = new SearchVMValidator();
            var result = validator.Validate(searchEM);
            Assert.IsFalse(result.IsValid);
        }
        [Test]
        public void ShouldValidateTitleAndDesriptionHaveCorrectLenght()
        {
            var searchEM = new SearchEngineModel
            {
                PhoneNumber = "111111111",
                Title = "Tytuł 1234567",
                Description = "Opis 123456789"
            };
            var validator = new SearchVMValidator();
            var result = validator.Validate(searchEM);
            Assert.IsTrue(result.IsValid);
        }
        [Test]
        public void ShouldNotValidateDateAddedIsInFuture()
        {
            var searchEM = new SearchEngineModel
            {
                PhoneNumber = "111111111",
                Title = "Tytuł 1234567",
                Description = "Opis 123456789",
                DateAdded = DateTime.Now.AddYears(20)                
            };
            var validator = new SearchVMValidator();
            var result = validator.Validate(searchEM);
            Assert.IsFalse(result.IsValid);
        }
    }
}
