using EducationPlatform.Application.Commands.VideoLessonCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Validators
{
    public class UpdateVideoLessonCommandValidator : AbstractValidator<UpdateVideoLessonCommand>
    {
        public UpdateVideoLessonCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotNull().WithMessage("O preenchimento do nome é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do nome é obrigatório.");

            RuleFor(v => v.Description)
                .NotNull().WithMessage("O preenchimento da descrição é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento da descrição é obrigatório.");
        }
    }
}
