using EducationPlatform.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.SubscriptionCommands
{
    public class CreateSubscriptionCommand : IRequest<ServiceResult<int>>
    {
        public string Name { get; set; }
        public int DurationInDays { get; set; }
    }
}
