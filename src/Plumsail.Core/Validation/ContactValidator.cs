using System;
using Microsoft.Extensions.Localization;
using FluentValidation;

using Plumsail.Core.Models;
using Plumsail.Core.Localization;

namespace Plumsail.Core.Validation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator(IStringLocalizer<Contact> localizer)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage(c => localizer[ContactLocalizer.NameRequired]);

            RuleFor(c => c.Surname)
                .NotEmpty()
                .WithMessage(c => localizer[ContactLocalizer.SurnameRequired]);

            //Todo
            RuleFor(c => c.BirthDate)
                .GreaterThan(new DateTime(1900, 1, 1))
                .WithMessage(c => localizer[ContactLocalizer.BirthDateInvalid]);

            RuleFor(c => c.Gender)
                .NotEqual(Gender.Undefined)
                .WithMessage(c => localizer[ContactLocalizer.GenderRequired]);
        }
    }
}
