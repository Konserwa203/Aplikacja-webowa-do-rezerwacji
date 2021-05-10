using NUnit.Framework;
using RezerwacjaPOL.Models;
using RezerwacjaPOL.Models.Validators;

namespace RezerwacjePOLTest
{
    [TestFixture]
    public class LoginVMValidatorTests
    {

        [Test]
        public void ShouldValidateIfEmailAndPasswordAreProvided()
        {
            var loginVM = new LoginViewModel
            {
                Email = "test@example.com",
                Password = "test123"
            };
            var validator = new LoginVMValidator();

            var result = validator.Validate(loginVM);

            Assert.IsTrue(result.IsValid);
        }

        [Test]
        public void ShouldNotValidateIfEmailIsWrong()
        {
            var loginVM = new LoginViewModel
            {
                Email = "test.test",
                Password = "test123"
            };
            var validator = new LoginVMValidator();

            var result = validator.Validate(loginVM);

            Assert.IsFalse(result.IsValid);
        }

        [Test]
        public void ShouldNotValidateIfEmailIsNotProvided()
        {
            var loginVM = new LoginViewModel
            {
                Password = "test123"
            };
            var validator = new LoginVMValidator();

            var result = validator.Validate(loginVM);

            Assert.IsFalse(result.IsValid);
        }


    }
}