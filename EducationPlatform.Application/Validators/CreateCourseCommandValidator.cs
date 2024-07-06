using EducationPlatform.Application.Commands.CourseCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Validators
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(c => c.SubscriptionId)
                .GreaterThanOrEqualTo(0).WithMessage("O Id da assinatura não pode ser negativo.");

            RuleFor(c => c.Name)
                .NotNull().WithMessage("O preenchimento do nome é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do nome é obrigatório.");

            RuleFor(c => c.Description)
                .NotNull().WithMessage("O preenchimento da descrição é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento da descrição é obrigatório.");

            RuleFor(c => c.Cover)
                .NotNull().WithMessage("O cadastro da capa do curso obrigatório.")
                .NotEmpty().WithMessage("O cadastro da capa do curso obrigatório.");

        }
    }
}
