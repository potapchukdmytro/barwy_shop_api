﻿using FluentValidation;
using Infrastructure.Models.Account;

namespace Infrastructure.Validation
{
    public class RegisterValidation : AbstractValidator<RegisterVM>
    {
        public RegisterValidation()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Password).NotEmpty().MinimumLength(6).Equal(r => r.ConfirmPassword);
            RuleFor(r => r.ConfirmPassword).NotEmpty().MinimumLength(6).Equal(r => r.Password);
        }
    }
}
