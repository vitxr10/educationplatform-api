using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest
    {
        public UpdateUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
