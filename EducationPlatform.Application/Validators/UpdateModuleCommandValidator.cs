using EducationPlatform.Application.Commands.ModuleCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Validators
{
    public class UpdateModuleCommandValidator : AbstractValidator<UpdateModuleCommand>
    {
        public UpdateModuleCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("O preenchimento do nome é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do nome é obrigatório.");

            RuleFor(c => c.Description)
                .NotNull().WithMessage("O preenchimento da descrição é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento da descrição é obrigatório.");
        }
    }
}
