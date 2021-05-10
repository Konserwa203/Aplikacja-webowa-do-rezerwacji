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

      
    }
}