using EducationPlatform.Application.Commands.UserCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.FullName)
                .NotNull().WithMessage("O preenchimento do nome é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do nome é obrigatório.");

            RuleFor(u => u.Document)
                .NotNull().WithMessage("O preenchimento do CPF é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do CPF é obrigatório.")
                .Must(ValidCPF).WithMessage("CPF inválido.");

            RuleFor(u => u.Email)
                .NotNull().WithMessage("O preenchimento do email é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(u => u.Password)
                .NotNull().WithMessage("O preenchimento da senha é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento da senha é obrigatório.")
                .Must(ValidPassword).WithMessage("A senha deve conter 8 caracteres, letras, números e caracteres especiais.");

            RuleFor(u => u.Phone)
                .NotNull().WithMessage("O preenchimento do telefone é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento do telefone é obrigatório.");

            RuleFor(u => u.BirthDate)
                .NotNull().WithMessage("O preenchimento da data de nascimento é obrigatório.")
                .NotEmpty().WithMessage("O preenchimento da data de nascimento é obrigatório.")
                .LessThan(DateTime.Now).WithMessage("Data de nascimento inválida.");

            RuleFor(u => u.SubscriptionId)
                .GreaterThanOrEqualTo(0).WithMessage("O Id da assinatura não pode ser negativo.");
        }

        public static bool ValidCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += int.Parse(cpf[i].ToString()) * (10 - i);
            int remainder = sum % 11;
            int verificationDigit1 = remainder < 2 ? 0 : 11 - remainder;
            if (int.Parse(cpf[9].ToString()) != verificationDigit1)
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(cpf[i].ToString()) * (11 - i);
            remainder = sum % 11;
            int verificationDigit2 = remainder < 2 ? 0 : 11 - remainder;
            if (int.Parse(cpf[10].ToString()) != verificationDigit2)
                return false;

            return true;
        }

        public static bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
