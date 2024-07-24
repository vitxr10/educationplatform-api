using EducationPlatform.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest<ServiceResult>
    {
        public UpdateUserCommand(string email, string phone)
        {
            Email = email;
            Phone = phone;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
