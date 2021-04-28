using FluentValidation.TestHelper;
using GL.Services.Validators;
using System;
using Xunit;

namespace GL.Tests
{
    public class CompanyValidatorTests
    {
        private readonly CompanyValidator _validator = new CompanyValidator();

        [Fact]
        public void GivenInvalidISIN_ShouldHaveValidationError()
        {
            _validator.ShouldHaveValidationErrorFor(model => model.ISIN, "12ABC");
        }
    }
}