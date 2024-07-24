using EducationPlatform.Application.Common;
using EducationPlatform.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.AuthCommands
{
    public class AuthCommand : IRequest<ServiceResult<AuthViewModel>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
