using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.ModuleCommands
{
    public class CreateModuleCommand : IRequest<int>
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
