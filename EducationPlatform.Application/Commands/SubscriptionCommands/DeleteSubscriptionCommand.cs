using EducationPlatform.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.SubscriptionCommands
{
    public class DeleteSubscriptionCommand : IRequest<ServiceResult>
    {
        public DeleteSubscriptionCommand()
        {
        }

        public DeleteSubscriptionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
