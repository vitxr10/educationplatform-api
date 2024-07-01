using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.SubscriptionCommands
{
    public class UpdateSubscriptionCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
