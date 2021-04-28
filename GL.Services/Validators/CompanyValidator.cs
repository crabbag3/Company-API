using FluentValidation;
using GL.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Services.Validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Exchange).NotEmpty();
            RuleFor(x => x.Ticker).NotEmpty();
            RuleFor(x => x.ISIN).Matches("^[A - Za - z]{2}"); // ensure first 2 characters are alpha characters
        }
    }
}