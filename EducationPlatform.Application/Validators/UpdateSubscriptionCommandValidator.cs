using EducationPlatform.Application.Commands.SubscriptionCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Validators
{
    public class UpdateSubscriptionCommandValidator : AbstractValidator<UpdateSubscriptionCommand>
    {
        public UpdateSubscriptionCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("O preenchimento do nome é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do nome é obrigatório.");
        }
    }
}
