using System;
using Microsoft.Extensions.Localization;
using FluentValidation;

using Plumsail.Core.Models;
using Plumsail.Core.Localization;

namespace Plumsail.Core.Validation
{
    public class PhoneValidator : AbstractValidator<Phone>
    {
        public PhoneValidator(IStringLocalizer<Phone> localizer)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(x => localizer[PhoneLocalizer.TitleRequired]);

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage(x => localizer[PhoneLocalizer.PriceInvalid]);

            RuleFor(x => x.ProductionDate)
                .GreaterThan(new DateTime(1900, 1, 1))
                .WithMessage(x => localizer[PhoneLocalizer.ProductionDateInvalid]);

            RuleFor(x => x.Color)
                .NotEmpty()
                .WithMessage(x => localizer[PhoneLocalizer.ColorRequired]);

            RuleFor(x => x.Memory)
                .GreaterThan(0)
                .WithMessage(x => localizer[PhoneLocalizer.MemoryInvalid]);
        }
    }
}
