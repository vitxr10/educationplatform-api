using EducationPlatform.Application.Commands.ModuleCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Validators
{
    public class CreateModuleCommandValidator : AbstractValidator<CreateModuleCommand>
    {
        public CreateModuleCommandValidator()
        {
            RuleFor(m => m.CourseId)
                .GreaterThan(0).WithMessage("O Id do curso não pode ser negativo ou igual a zero");

            RuleFor(m => m.Name)
                .NotNull().WithMessage("O preenchimento do nome é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do nome é obrigatório.");

            RuleFor(m => m.Description)
                .NotNull().WithMessage("O preenchimento da descrição é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento da descrição é obrigatório.");
        }
    }
}
