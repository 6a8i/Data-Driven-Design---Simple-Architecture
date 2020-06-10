using System;
using Data.Driven.Design.API.Models.Custumer;
using FluentValidation;

namespace Data.Driven.Design.Application.Validations.Custumer
{
    public class InsertCustumerValidator : CustomValidator<InsertCustumer.Request>
    {
        protected override void RegisterValidations()
        {
            ValidateName();
            ValidateEmail();
            ValidatePassword();
        }

        private void ValidateName()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The Name field can't be null or empty.");
        }

        private void ValidateEmail()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("The Email field can't be null or empty.");
        }

        private void ValidatePassword()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("The Paswword field can't be null or empty.");
        }
    }
}
