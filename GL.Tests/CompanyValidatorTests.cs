using FluentValidation.TestHelper;
using GlassLewis.Services.Validators;
using Xunit;

namespace GlassLewis.Tests
{
    public class CompanyValidatorTests
    {
        private readonly CompanyBindingModelValidator _validator = new CompanyBindingModelValidator();

        [Fact]
        public void GivenInvalidISIN_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(model => model.ISIN, "12ABC");
        }

        [Fact]
        public void GivenValidISIN_ShouldHaveValidationError()
        {
            _validator.ShouldNotHaveValidationErrorFor(model => model.ISIN, "ES123");
        }
    }
}