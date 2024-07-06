using EducationPlatform.Application.Commands.AuthCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Validators
{
    public class AuthCommandValidator : AbstractValidator<AuthCommand>
    {
        public AuthCommandValidator()
        {
            RuleFor(a => a.Email)
                .NotNull().WithMessage("O preenchimento do email é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(u => u.Password)
                .NotNull().WithMessage("O preenchimento da senha é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento da senha é obrigatório.");
        }
    }
}
