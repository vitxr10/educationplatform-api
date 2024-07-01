using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.SubscriptionCommands
{
    public class DeleteSubscriptionCommand : IRequest
    {
        public DeleteSubscriptionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
