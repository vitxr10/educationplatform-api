using EducationPlatform.Application.Commands.UserCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotNull().WithMessage("O preenchimento do email é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(u => u.Phone)
                .NotNull().WithMessage("O preenchimento do telefone é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do telefone é obrigatório.");
        }
    }
}
