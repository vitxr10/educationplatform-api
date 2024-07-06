using EducationPlatform.Application.Commands.VideoLessonCommands;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Validators
{
    public class CreateVideoLessonCommandValidator : AbstractValidator<CreateVideoLessonCommand>
    {
        public CreateVideoLessonCommandValidator()
        {
            RuleFor(v => v.ModuleId)
                .GreaterThan(0).WithMessage("O Id do módulo não pode ser negativo ou igual a zero");

            RuleFor(v => v.Name)
                .NotNull().WithMessage("O preenchimento do nome é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do nome é obrigatório.");

            RuleFor(v => v.Description)
                .NotNull().WithMessage("O preenchimento da descrição é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento da descrição é obrigatório.");

            RuleFor(x => x.Video)
                .NotEmpty().WithMessage("O cadastro vídeo é obrigatório.")
                .NotNull().WithMessage("O cadastro vídeo é obrigatório.")
                .Must(BeAMp4Video).WithMessage("O arquivo deve ser um vídeo mp4.");
        }

        private bool BeAMp4Video(IFormFile file)
        {
            return file != null && file.ContentType == "video/mp4";
        }
    }
}
